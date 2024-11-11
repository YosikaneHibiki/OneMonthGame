using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CarDataBase",menuName = "Data/Car/CarDataBase")]
public class CarDataBase : ScriptableObject
{
    public List<CarDeta> carDetaBase;
}
