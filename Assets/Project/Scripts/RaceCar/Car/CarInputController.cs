using UnityEngine;
using UnityEngine.InputSystem;

public class CarInputController : MonoBehaviour, IRaceStart
{
    [SerializeField]
    private RaceManager raceManager;
    [SerializeField]
    private EscapeMenu escapeMenu;

    private CarAction carAction;
    private CarAction.CarActionMapActions carActionMapActions;

    public float GasInput { get; private set; }
    public float BrakeInput { get; private set; }
    public float SteeringInput { get; private set; }

    private void Awake()
    {
        carAction = new CarAction();
        carActionMapActions = carAction.CarActionMap;
    }

    private void KeySeting()
    {
        carActionMapActions.PauseButton.started += OnPauseMenu;
        carActionMapActions.ResetKey.started += OnReset;
        carActionMapActions.MoveAction.performed += OnGasInput;
        carActionMapActions.MoveAction.canceled += OnGasCancel;
        carActionMapActions.Brake.performed += OnBrake;
        carActionMapActions.Brake.canceled += OnBrakeCancel;
        carAction.Enable();
    }

    private void FixedUpdate()
    {
        SteeringInput = Input.GetAxis("Horizontal");
    }


    private void OnDisable()
    {
        carAction.Disable();
    }

    private void OnGasInput(InputAction.CallbackContext context)
    {
        GasInput = context.ReadValue<float>();
    }

    private void OnGasCancel(InputAction.CallbackContext context)
    {
        GasInput = 0;
    }

    private void OnBrake(InputAction.CallbackContext context)
    {
        BrakeInput = context.ReadValue<float>();
    }

    private void OnBrakeCancel(InputAction.CallbackContext context)
    {
        BrakeInput = 0;
    }

    private void OnReset(InputAction.CallbackContext context)
    {
        raceManager.CarReset();
    }

    private void OnPauseMenu(InputAction.CallbackContext context)
    {
        escapeMenu.OpenMenu();
    }

    public void RaceStart()
    {
        KeySeting();
    }
}
