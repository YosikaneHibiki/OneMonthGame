using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectUI : MonoBehaviour
{
    [SerializeField]
    private SpeedMeter speedMeter;
    [SerializeField]
    private Wheel_UI wheel_UI;

    public void Inject(CarController carController , WheelController[] wheelControllers)
    {
        speedMeter.InjectUI(carController);
        wheel_UI.InjectUI(wheelControllers);
    }
}
