using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameType
{
    Radey,
    Start,
    Goal
}

public class CarController : MonoBehaviour , IResetPostion
{
    [SerializeField]
    private RaceManager raceManager;
    [SerializeField]
    private CarInputController inputController;
    [SerializeField]
    private CarID carID;
    private CarData carDeta;

    //クルマのデータ
    public float MaxSpeed { get; private set; }
    //タイヤのデータ
    public WheelColliders colliders;
    public WheelMeshes wheelMeshes;
    //クルマののドメイン
    private ICarRepository carRepository;
    public GameType gameType;
    //現在のクルマの速度や角度
    public float slipAngle;
    public float speed;
    private Rigidbody playerRB;
    
    public void Inject(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    private void Start()
    {
        carDeta = carRepository.FindCar(carID.Id);

        MaxSpeed = carDeta.maxSpeed;
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(gameType == GameType.Radey) { return; }
        if(gameType == GameType.Goal)
        {
            ApplyBrake();
            return;
        }

        speed = playerRB.velocity.magnitude * 3.5f;
        CheckInput();
        ApplyMotor();
        ApplySteering();
        ApplyBrake();
        ApplyWheelPositions();
    }

    private void CheckInput()
    {
        slipAngle = Vector3.Angle(transform.forward, playerRB.velocity - transform.forward);
    }

    private void ApplyBrake()
    {
        colliders.FRWheel.brakeTorque = inputController.BrakeInput * carDeta.brakePower * 0.7f;
        colliders.FLWheel.brakeTorque = inputController.BrakeInput * carDeta.brakePower * 0.7f;

        colliders.RRWheel.brakeTorque = inputController.BrakeInput * carDeta.brakePower * 0.3f;
        colliders.RLWheel.brakeTorque = inputController.BrakeInput * carDeta.brakePower * 0.3f;
    }

    private void ApplyMotor()
    {

        colliders.FLWheel.motorTorque = carDeta.motorPower * carDeta.FrontTorque * inputController.GasInput;
        colliders.FRWheel.motorTorque = carDeta.motorPower * carDeta.FrontTorque * inputController.GasInput;
        colliders.RRWheel.motorTorque = carDeta.motorPower * carDeta.RiaTorque * inputController.GasInput;
        colliders.RLWheel.motorTorque = carDeta.motorPower * carDeta.RiaTorque * inputController.GasInput;
    }

    private void ApplySteering()
    {
        float steeringAngle = inputController.SteeringInput * carDeta.steeringCurve.Evaluate(speed);

        if (slipAngle < 120f)
        {
            steeringAngle += Vector3.SignedAngle(transform.forward, playerRB.velocity + transform.forward, Vector3.up);
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

    public void ChecekPoint(CheckPointData checkPointData)
    {
        raceManager.Checkpoint(checkPointData);
    }

    public void ResetPostion(Vector3 resetPostion)
    {
        this.gameObject.transform.position = resetPostion;
        this.transform.rotation = Quaternion.LookRotation(transform.forward);
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

