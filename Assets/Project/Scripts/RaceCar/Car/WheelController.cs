using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{

    private WheelCollider wheelCollider;
    private WheelFrictionCurve wheelFrictionCurve;
    private WheelFrictionCurve defaltWheelFruction;
    public float SlipValue {  get; private set; }


    private void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
        defaltWheelFruction = wheelCollider.sidewaysFriction;
    }

    private void Update()
    {
        WheelHit wheelHit;
        wheelCollider.GetGroundHit(out wheelHit);
        SlipValue = Mathf.Abs(wheelHit.sidewaysSlip);

        if (SlipValue > 0.4)
        {
            Debug.Log("スライドを検知" + SlipValue);
            wheelFrictionCurve = wheelCollider.sidewaysFriction;
            wheelFrictionCurve.stiffness = 1.3f;
            wheelFrictionCurve.extremumSlip =1f;
            wheelFrictionCurve.asymptoteSlip =1f;
            wheelFrictionCurve.extremumValue = 1f;
            wheelFrictionCurve.asymptoteValue = 1f;
            wheelCollider.sidewaysFriction = wheelFrictionCurve;
        }
        else
        {
            wheelCollider.sidewaysFriction = defaltWheelFruction;
        }

    }
}
