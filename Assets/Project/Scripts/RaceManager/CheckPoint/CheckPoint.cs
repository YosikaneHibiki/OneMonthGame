using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField]
    private int CheckPointNumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<CarController>(out var car))
        {
            var checekPointData = new CheckPointData(CheckPointNumber,transform);
            car.ChecekPoint(checekPointData);
        }
    }
}
