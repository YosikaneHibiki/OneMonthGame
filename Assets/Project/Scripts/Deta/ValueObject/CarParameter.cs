using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParameter
{
    public readonly float motorPower;
    public readonly float brakePower;
    public readonly float maxSpeed;
    public readonly AnimationCurve steeringCurve;
    public readonly float FrontTorque;
    public readonly float RiaTorque;

    public CarParameter(float motorPower, float brakePower, 
        float maxSpeed, AnimationCurve animationCurve)
    {
        this.motorPower = motorPower;
        this.brakePower = brakePower;
        this.maxSpeed = maxSpeed;
        this.steeringCurve = animationCurve;
    }

    public CarParameter(CarData carData)
    {
        motorPower = carData.motorPower;
        brakePower = carData.brakePower;
        maxSpeed = carData.maxSpeed;
        steeringCurve = carData.steeringCurve;
        FrontTorque = carData.FrontTorque;
        RiaTorque = carData.RiaTorque;
    }

}
