using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{
    [SerializeField]
    private Image wheelImage;

    private WheelCollider wheelCollider;
    private WheelFrictionCurve wheelFrictionCurve;

    private WheelFrictionCurve defaltWheelFruction;


    private void Start()
    {

        wheelCollider = GetComponent<WheelCollider>();
        defaltWheelFruction = wheelCollider.sidewaysFriction;
    }

    private void Update()
    {
        WheelHit wheelHit;
        wheelCollider.GetGroundHit(out wheelHit);
        wheelImage.color = new Color(Mathf.Abs(wheelHit.sidewaysSlip), 0, 0);

        if (wheelHit.sidewaysSlip > 0.4)
        {
            Debug.Log("スライドを検知" + wheelHit.sidewaysSlip);
            wheelFrictionCurve = wheelCollider.sidewaysFriction;
            wheelFrictionCurve.stiffness = 1.3f;
            wheelFrictionCurve.extremumSlip = 0.8f;
            wheelFrictionCurve.asymptoteSlip = 0.8f;
            wheelFrictionCurve.extremumValue = 0.7f;
            wheelFrictionCurve.asymptoteValue = 0.7f;
            wheelCollider.sidewaysFriction = wheelFrictionCurve;
        }
        else
        {
            wheelCollider.sidewaysFriction = defaltWheelFruction;
        }

    }
}
