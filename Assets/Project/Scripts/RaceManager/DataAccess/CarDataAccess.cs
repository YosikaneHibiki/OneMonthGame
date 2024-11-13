using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarDataAccess : ICarRepository
{
    private readonly CarDataBase carDataBase;
    
    public CarDataAccess(CarDataBase carDataBase)
    {
        this.carDataBase = carDataBase;
    }

    public CarData FindCar(string carId)
    {
        if(carId == string.Empty)
        {
            throw new System.Exception("ID‚ª‹ó‚Å‚·");
        }

        return carDataBase.carDetaBase
            .Where(car=>car.carID.Id == carId)
            .FirstOrDefault();
    }
}
