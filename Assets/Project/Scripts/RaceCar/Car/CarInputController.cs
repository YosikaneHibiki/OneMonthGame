using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarInputController : MonoBehaviour
{
    private CarAction carAction;
    private CarAction.CarActionMapActions carActionMapActions;
    public float GasInput { get; private set; }
    public float BrakeInput { get; private set; }
    public float SteeringInput {  get; private set; }

    private void Awake()
    {
        carAction = new CarAction();
        carActionMapActions = carAction.CarActionMap;
    }

    private void OnEnable()
    {
        carActionMapActions.MoveAction.performed += OnGasInput;
        carActionMapActions.MoveAction.canceled += OnGasCancel;
        carActionMapActions.Brake.performed += OnBrake;
        carActionMapActions.Brake.canceled += OnBrakeCancel;
        carActionMapActions.HandleAction.performed += OnSteeringInput;
        carActionMapActions.HandleAction.canceled += OnSteeringCancel;

        carAction.Enable();
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

    private void OnSteeringInput(InputAction.CallbackContext context)
    {
        SteeringInput = context.ReadValue<Vector2>().x;
    }

    private void OnSteeringCancel(InputAction.CallbackContext context)
    {
        SteeringInput = 0;
    }

    private void OnBrake(InputAction.CallbackContext context)
    {
        BrakeInput = context.ReadValue<float>();
    }

    private void OnBrakeCancel(InputAction.CallbackContext context)
    {
        BrakeInput = 0;
    }

}
