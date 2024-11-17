using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour ,IRaceEnd
{

    [SerializeField]
    private int CheckPointNumber;

    private bool isGameEnd;

    public void RaceEnd()
    {
        isGameEnd = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGameEnd)
        {
            return;
        }

        if(other.gameObject.TryGetComponent<CarController>(out var car))
        {
            var checekPointData = new CheckPointData(CheckPointNumber,transform);
            car.ChecekPoint(checekPointData);
        }
    }
}
