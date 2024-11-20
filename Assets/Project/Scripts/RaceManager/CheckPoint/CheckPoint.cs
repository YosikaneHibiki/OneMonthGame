using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour ,IRaceEnd
{

    [SerializeField]
    private int CheckPointNumber;
    private RaceManager raceManager;
    private bool isGameEnd;

    private void Start()
    {
        raceManager = RaceManager.Instance;
    }

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
            raceManager.Checkpoint(checekPointData);
        }
    }
}
