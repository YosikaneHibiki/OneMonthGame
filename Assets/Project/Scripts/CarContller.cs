using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CarContller : MonoBehaviour
{
    [SerializeField]
    private CarAction carAction;
    [SerializeField]
    private WheelCollider LeftFront, RightFront, LeftRia, RightRia;
    [SerializeField]
    private float MaxPowr;
    [SerializeField]
    private float angle;
    [SerializeField]
    private float brakePower;

    [SerializeField]
    private int GearAmount;

    [SerializeField]
    private Text text;

    public float slipThreshold = 0.0005f; // スリップの閾値


    private void Awake()
    {
        carAction = new CarAction();
    }

    private void Update()
    {
        WheelHit hit;
        if (LeftRia.GetGroundHit(out hit))
        {
            // 前後方向と左右方向のスリップをチェック
            float sidewaysSlip = Mathf.Abs(hit.sidewaysSlip);

            if ( sidewaysSlip > slipThreshold)
            {
                LeftRia.motorTorque = MaxPowr / 3;
                Debug.Log("左スライドを確認"+sidewaysSlip);
            }
        }

        if(LeftRia.GetGroundHit(out hit))
        {
            // 前後方向と左右方向のスリップをチェック
            float sidewaysSlip = Mathf.Abs(hit.sidewaysSlip);
            // スリップの閾値を超えているかどうかを確認
            if (sidewaysSlip > slipThreshold)
            {
                RightRia.motorTorque = MaxPowr/3;
                Debug.Log("右スライドを確認"+sidewaysSlip);
            }
        }

        text.text = GearAmount.ToString();
    }

    private void OnEnable()
    {
        carAction.CarActionMap.MoveAction.performed += OnAccele;
        carAction.CarActionMap.MoveAction.canceled += OnAcceleCancel;
        carAction.CarActionMap.HandleAction.performed += OnHandle;
        carAction.CarActionMap.HandleAction.canceled += OnHandleCancel;
        carAction.CarActionMap.Brake.performed += OnBrake;
        carAction.CarActionMap.Brake.canceled += OnBreakCancel;
        carAction.CarActionMap.GearDownAction.started += OnGearDown;
        carAction.CarActionMap.gearUpAction.started += OnGearUp;

        carAction.Enable();
    }

    private void OnGearUp(InputAction.CallbackContext context)
    {
        GearAmount++;
        GearAmount = Mathf.Clamp(GearAmount, -1, 6);
    }

    private void OnGearDown(InputAction.CallbackContext context)
    {
        GearAmount--;
        GearAmount = Mathf.Clamp(GearAmount, -1, 6);
    }

    private void OnAccele(InputAction.CallbackContext context)
    {
        var moveSpeed = context.ReadValue<float>()*MaxPowr;
        if(GearAmount == -1)
        {
            moveSpeed = -300;
        }

        LeftRia.motorTorque = moveSpeed;
        RightRia.motorTorque = moveSpeed;
        LeftFront.motorTorque = moveSpeed/2;
        RightFront.motorTorque = moveSpeed/2;
    }

    private void OnAcceleCancel(InputAction.CallbackContext context)
    {
        LeftRia.motorTorque = 0;
        RightRia.motorTorque = 0;
        LeftFront.motorTorque = 0;
        RightFront.motorTorque = 0;
    }

    private void OnHandle(InputAction.CallbackContext context)
    {
        float carAngele = angle * context.ReadValue<Vector2>().x;
        LeftFront.steerAngle = carAngele;
        RightFront.steerAngle = carAngele;
    }

    private void OnHandleCancel(InputAction.CallbackContext context)
    {
        LeftFront.steerAngle = 0;
        RightFront.steerAngle = 0;
    }

    private void OnBrake(InputAction.CallbackContext context)
    {
        LeftFront.brakeTorque = brakePower;
        RightFront.brakeTorque = brakePower;

    }


    private void OnBreakCancel(InputAction.CallbackContext callback)
    {
        LeftFront.brakeTorque = 0;
        RightFront.brakeTorque = 0;
    }

}
