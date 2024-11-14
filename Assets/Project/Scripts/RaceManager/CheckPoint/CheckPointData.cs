using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointData
{
    public readonly int CheckPointNumber;
    public readonly Transform transform;
    public CheckPointData(int checkPointNumber, Transform transform)
    {
        CheckPointNumber = checkPointNumber;
        this.transform = transform;
    }
}
