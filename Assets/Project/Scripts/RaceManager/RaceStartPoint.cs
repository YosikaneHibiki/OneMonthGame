using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStartPoint : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private CarID carDefaltID;
    private ICarRepository carRepository;

    public void Inject(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    public void CreateCar(string carId)
    {
        if(carId == null)
        {
            carId = carDefaltID.Id;
        }


        var carData = carRepository.FindCar(carId);
        Instantiate(carData.CarPrefab,startPoint.transform.position,Quaternion.identity);
    }
}
