using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICarRepository
{
    CarDeta FindCar(string carId);
}
