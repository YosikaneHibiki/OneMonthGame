using UnityEngine;

public class AntiRollBar : MonoBehaviour
{

    public WheelColliders colliders;
    public float AntiRoll = 5000.0f;

    private Rigidbody car;

    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        WheelHit hit;
        float travelFL = 1.0f;
        float travelFR = 1.0f;
        float travelRL = 1.0f;
        float travelRR = 1.0f;


        bool groundedFL = colliders.FLWheel.GetGroundHit(out hit);
        if (groundedFL)
        {
            travelFL = (-colliders.FLWheel.transform.InverseTransformPoint(hit.point).y - colliders.FLWheel.radius) / colliders.FLWheel.suspensionDistance;
        }

        bool groundedRL = colliders.RLWheel.GetGroundHit(out hit);
        if (groundedRL)
        {
            travelRL = (-colliders.RLWheel.transform.InverseTransformPoint(hit.point).y - colliders.RLWheel.radius) / colliders.RLWheel.suspensionDistance;
        }
        bool groundedRR = colliders.RLWheel.GetGroundHit(out hit);
        if (groundedRL)
        {
            travelRR = (-colliders.RLWheel.transform.InverseTransformPoint(hit.point).y - colliders.RLWheel.radius) / colliders.RLWheel.suspensionDistance;
        }


        bool groundedFR = colliders.FRWheel.GetGroundHit(out hit);
        if (groundedFR)
        {
            travelFR = (-colliders.FRWheel.transform.InverseTransformPoint(hit.point).y - colliders.FRWheel.radius) / colliders.FRWheel.suspensionDistance;
        }

        float antiFrontRollForce = (travelFL - travelFR) * AntiRoll;

        if (groundedFL)
            car.AddForceAtPosition(colliders.FLWheel.transform.up * -antiFrontRollForce, colliders.FLWheel.transform.position);

        if (groundedFR)
            car.AddForceAtPosition(colliders.FRWheel.transform.up * antiFrontRollForce, colliders.FRWheel.transform.position);
    }

    public void CarAddForce(float antiRollForce,WheelCollider wheelCollider,Rigidbody car)
    {
        car.AddForceAtPosition(wheelCollider.transform.up * antiRollForce, wheelCollider.transform.position);
    }

    private float AnitRoll(WheelCollider wheelCollider ,WheelHit hit)
    {
        return (-wheelCollider.transform.InverseTransformPoint(hit.point).y - wheelCollider.radius) / wheelCollider.suspensionDistance;
    }

}
