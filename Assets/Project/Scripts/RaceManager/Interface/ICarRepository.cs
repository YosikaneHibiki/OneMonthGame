using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICarRepository
{
    CarData FindCar(string carId);
}
