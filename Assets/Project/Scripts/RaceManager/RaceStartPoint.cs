using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStartPoint : MonoBehaviour
{
    [SerializeField]
    private Transform lookTransform;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private CarID carDefaltID;
    [SerializeField]
    private InjectUI injectUI;
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    private CarReset carReset;
    [SerializeField]
    private CarEvent carEvent;
    
    private ICarRepository carRepository;

    public void Inject(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    public void CreateCar(string carId)
    {
        if(carId == null || carId == string.Empty)
        {
            carId = carDefaltID.Id;
        }
        var carData = carRepository.FindCar(carId);
        var carParameter = new CarParameter(carData);
        var carObject = Instantiate(carData.CarPrefab,startPoint.transform);
        var carController = carObject.GetComponent<CarController>();
        carController.SetParameter(carParameter);
        WheelController[] wheelControllers = carObject.GetComponentsInChildren<WheelController>();
        injectUI.Inject(carController,wheelControllers);
        carEvent.Inject(carController);

        virtualCamera.Follow = carObject.transform;
        virtualCamera.LookAt = carObject.transform;

        carReset.Inject(carController);
    }


}
