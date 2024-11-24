using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEntoryPoint : MonoBehaviour ,IEntoryPoint
{
    public void EntoryPoint(EntoryPointData entoryPoint)
    {
        Debug.Log(entoryPoint.carId);
    }
}
