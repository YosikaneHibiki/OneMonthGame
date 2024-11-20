using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceEntoryPoint : MonoBehaviour
{
    [SerializeField]
    private RaceStartPoint startPoint;
    public CarID carID;
    public void Entory()
    {
        startPoint.CreateCar(carID.Id);
    }
}
