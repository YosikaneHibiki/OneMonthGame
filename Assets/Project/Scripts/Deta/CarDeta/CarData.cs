using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New CarData",menuName = "Data/Car/CarData")]
public class CarData : ScriptableObject
{
    public CarID carID;
    public string Name;
    //クルマのデータ
    public float motorPower;
    public float brakePower;
    public float maxSpeed;
    public AnimationCurve steeringCurve;

    [Range(0f, 1f)]
    public float Torque;

    public float FrontTorque;
    public float RiaTorque;

    public void OnValidate()
    {
        FrontTorque = Mathf.Abs(1-Torque);
        RiaTorque = Torque;
    }

}
