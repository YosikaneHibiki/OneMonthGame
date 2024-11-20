using UnityEngine;

public enum GameType
{
    Radey,
    Start,
    Goal
}

public class CarController : MonoBehaviour
{
    [SerializeField]
    private CarID carID;

    private CarInputController inputController;
    private AudioSource audioSource;
    private RaceManager raceManager;
    private CarParameter carParameter;
    private AudioManager audioManager;
    private float resetTime = 0f;
    private Rigidbody playerRB;

    //クルマのデータ
    public float MaxSpeed { get; private set; }
    //タイヤのデータ
    public WheelColliders colliders;
    public WheelMeshes wheelMeshes;
    //クルマののドメイン
    public GameType gameType;
    //現在のクルマの速度や角度
    public float slipAngle;
    public float speed;
    public float floatingTime = 5.0f;

    public void SetParameter(CarParameter carParameter)
    {
        this.carParameter = carParameter;
    }

    private void Start()
    {

        raceManager = RaceManager.Instance;
        audioManager = AudioManager.Instance;
        inputController = gameObject.GetComponent<CarInputController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        playerRB = gameObject.GetComponent<Rigidbody>();
        audioManager.PlaySFX("15 EngA_06589", audioSource);
        MaxSpeed = carParameter.maxSpeed;
    }

    private void Update()
    {
        audioManager.PitchChange(audioSource, Mathf.Lerp(0f, 2f, speed / 180f));
        if (gameType == GameType.Radey) { return; }
        if (gameType == GameType.Goal)
        {
            GameEnd();
            return;
        }

        speed = playerRB.velocity.magnitude * 3.5f;
        GroundCheck();
        CheckInput();
        ApplyMotor(inputController.GasInput);
        ApplySteering(inputController.SteeringInput);
        ApplyBrake(inputController.BrakeInput);
        ApplyWheelPositions();
    }

    private void GroundCheck()
    {
        if (colliders.FLWheel.isGrounded && colliders.FRWheel.isGrounded &&
            colliders.RLWheel.isGrounded && colliders.RRWheel.isGrounded)
        {
            resetTime = 0f;
        }
        else
        {
            resetTime += Time.deltaTime;
        }

        if (resetTime >= floatingTime)
        {
            resetTime = 0;
            raceManager.CarReset();
        }
    }

    private void CheckInput()
    {
        slipAngle = Vector3.Angle(transform.forward, playerRB.velocity - transform.forward);
    }

    private void ApplyBrake(float brakeInput)
    {
        colliders.FRWheel.brakeTorque = brakeInput * carParameter.brakePower * 0.7f;
        colliders.FLWheel.brakeTorque = brakeInput * carParameter.brakePower * 0.7f;

        colliders.RRWheel.brakeTorque = brakeInput * carParameter.brakePower * 0.3f;
        colliders.RLWheel.brakeTorque = brakeInput * carParameter.brakePower * 0.3f;
    }

    private void ApplyMotor(float gasInput)
    {

        colliders.FLWheel.motorTorque = carParameter.motorPower * carParameter.FrontTorque * gasInput;
        colliders.FRWheel.motorTorque = carParameter.motorPower * carParameter.FrontTorque * gasInput;
        colliders.RRWheel.motorTorque = carParameter.motorPower * carParameter.RiaTorque * gasInput;
        colliders.RLWheel.motorTorque = carParameter.motorPower * carParameter.RiaTorque * gasInput;
    }

    private void ApplySteering(float steeringInput)
    {
        float steeringAngle = steeringInput * carParameter.steeringCurve.Evaluate(speed);

        if (slipAngle > 4f)
        {
            steeringAngle += Vector3.SignedAngle
                (transform.forward, playerRB.velocity + transform.forward, Vector3.up) * 0.75f;
        }
        steeringAngle = Mathf.Clamp(steeringAngle, -90, 90);
        colliders.FRWheel.steerAngle = steeringAngle;
        colliders.FLWheel.steerAngle = steeringAngle;
    }

    private void ApplyWheelPositions()
    {
        UpdateWheel(colliders.FRWheel, wheelMeshes.FRWheel);
        UpdateWheel(colliders.FLWheel, wheelMeshes.FLWheel);
        UpdateWheel(colliders.RRWheel, wheelMeshes.RRWheel);
        UpdateWheel(colliders.RLWheel, wheelMeshes.RLWheel);
    }

    private void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;
        coll.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }

    public void ResetPostion(CheckPointData checkPointData)
    {
        playerRB.velocity = Vector3.zero;
        this.gameObject.transform.position = checkPointData.transform.position;
        this.transform.rotation = Quaternion.LookRotation(-checkPointData.transform.right);
    }

    public void GameEnd()
    {
        gameType = GameType.Goal;
        playerRB.mass = 99999;
        playerRB.freezeRotation = true;
        ApplyBrake(999999999999999);
        ApplyMotor(0);
        ApplySteering(0);
    }


    public void RaceReadey()
    {
        gameType = GameType.Radey;
    }

    public void RaceStart()
    {
        gameType = GameType.Start;
        inputController.KeySeting();
    }

    public void RaceEnd()
    {
        gameType = GameType.Goal;
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void PauseCancel()
    {
        audioSource.UnPause();
    }
}

[System.Serializable]
public class WheelColliders
{
    public WheelCollider FRWheel;
    public WheelCollider FLWheel;
    public WheelCollider RRWheel;
    public WheelCollider RLWheel;
}
[System.Serializable]
public class WheelMeshes
{
    public MeshRenderer FRWheel;
    public MeshRenderer FLWheel;
    public MeshRenderer RRWheel;
    public MeshRenderer RLWheel;
}

