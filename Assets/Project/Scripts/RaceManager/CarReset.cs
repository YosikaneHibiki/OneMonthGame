using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarReset : MonoBehaviour, IResetPostion
{

    private CarController controller;

    public void Inject(CarController carController)
    {
        this.controller = carController;
    }

    public void ResetPostion(CheckPointData resetPostion)
    {
        controller.ResetPostion(resetPostion);
    }
}
