using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CarEvent : MonoBehaviour, IRaceReady, IRaceStart, IRaceEnd, IRacePause
{
    private CarController carController;

    public void Inject(CarController carController)
    {
        this.carController = carController;
    }

    public void RaceReadey()
    {
        carController.RaceReadey();
    }

    public void RaceStart()
    {
        carController.RaceStart();
    }

    public void RaceEnd()
    {
        carController.RaceEnd();
    }

    public void Pause()
    {
        carController.Pause();
    }

    public void PauseCancel()
    {
        carController.PauseCancel();
    }
}
