using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{

    private IRaceInput raceInput;
    private Rigidbody playerRB;
    private CarAction carAction;

    public WheelColliders colliders;
    public WheelMeshes wheelMeshes;
    public float gasInput;
    public float brakeInput;
    public float steeringInput;
    public float motorPower;
    public float brakePower;
    public float slipAngle;
    public AnimationCurve steeringCurve;
    public float speed;
    public float maxSpeed;
    
    public void Inject(IRaceInput raceInput)
    {
        this.raceInput = raceInput;
    }

    // Start is called before the first frame update
    private void Start()
    {
        raceInput.GameRadey();
        carAction = new CarAction();
        carAction.CarActionMap.Brake.performed += OnBrake;
        carAction.CarActionMap.Brake.canceled += OnBrakeCancell;
        carAction.CarActionMap.TestSystemAction.performed += OnTestSystem;
        carAction.CarActionMap.TestSystemAction.canceled += OnTestSystemCancell;
        carAction.Enable();

        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        speed = playerRB.velocity.magnitude * 3.5f;
        CheckInput();
        ApplyMotor();
        ApplySteering();
        ApplyBrake();
        ApplyWheelPositions();
    }

    private void CheckInput()
    {
        gasInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");

        slipAngle = Vector3.Angle(transform.forward, playerRB.velocity - transform.forward);


    }
    private void ApplyBrake()
    {
        colliders.FRWheel.brakeTorque = brakeInput * brakePower * 0.7f;
        colliders.FLWheel.brakeTorque = brakeInput * brakePower * 0.7f;

        colliders.RRWheel.brakeTorque = brakeInput * brakePower * 0.3f;
        colliders.RLWheel.brakeTorque = brakeInput * brakePower * 0.3f;
    }

    private void ApplyMotor()
    {

        colliders.RRWheel.motorTorque = motorPower * gasInput;
        colliders.RLWheel.motorTorque = motorPower * gasInput;
    }

    private void ApplySteering()
    {
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        if (slipAngle < 120f)
        {
            steeringAngle += Vector3.SignedAngle(transform.forward, playerRB.velocity + transform.forward, Vector3.up);
        }
        steeringAngle = Mathf.Clamp(steeringAngle, -90f, 90f);
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

    private void OnTestSystem(InputAction.CallbackContext callback)
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, 10);
    }

    private void OnTestSystemCancell(InputAction.CallbackContext callback)
    {
        colliders.FLWheel.motorTorque = 0;
        colliders.FRWheel.motorTorque = 0;
    }

    private void OnBrake(InputAction.CallbackContext context)
    {
        brakeInput = 1;
    }

    private void OnBrakeCancell(InputAction.CallbackContext context)
    {
        brakeInput = 0;
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

