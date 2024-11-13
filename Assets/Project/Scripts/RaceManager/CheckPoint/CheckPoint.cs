using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField]
    private int CheckPointNumber;
    private bool isCheckPoint;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (isCheckPoint) { return; }

        if(other.gameObject.TryGetComponent<CarController>(out var car))
        {
            isCheckPoint = true;
            var checekPointData = new CheckPointData(CheckPointNumber, this.transform.position);
            car.ChecekPoint(checekPointData);
        }
    }
}
