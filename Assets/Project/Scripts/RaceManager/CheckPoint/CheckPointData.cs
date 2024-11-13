using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointData : MonoBehaviour
{
    public readonly int CheckPointNumber;
    public readonly Vector3 CheckPointPosition;
    public CheckPointData(int checkPointNumber, Vector3 checkPointPosition)
    {
        CheckPointNumber = checkPointNumber;
        CheckPointPosition = checkPointPosition;
    }
}
