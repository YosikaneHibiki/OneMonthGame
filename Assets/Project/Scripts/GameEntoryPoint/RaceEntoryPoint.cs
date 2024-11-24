using Cysharp.Threading.Tasks;
using MackySoft.Navigathena;
using MackySoft.Navigathena.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RaceEntoryPoint : MonoBehaviour
{
    [SerializeField]
    private RaceStartPoint startPoint;
    [SerializeField]
    private CarID carID;

    public void EntoryPoint(EntoryPointData entoryPoint)
    {
        startPoint.CreateCar(entoryPoint.carId);
    }

}
