using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStartPoint : MonoBehaviour, IRaceReady, IRaceStart, IRaceEnd, IRacePause
{
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
    
    private CarController carController;

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
        var carParameter = new CarParameter(carData);
        var carObject = Instantiate(carData.CarPrefab,startPoint.transform.position,Quaternion.identity);
        var carController = carObject.GetComponent<CarController>();
        this.carController = carController;
        carController.SetParameter(carParameter);
        WheelController[] wheelControllers = carObject.GetComponentsInChildren<WheelController>();
        injectUI.Inject(carController,wheelControllers);
        virtualCamera.Follow = carObject.transform;
        virtualCamera.LookAt = carObject.transform;
        carReset.Inject(this.carController);
    }

    public void RaceReadey()
    {
        carController.RaceReadey();
    }

    public void RaceStart()
    {
        carController.RaceStart();
    }

    public void RaceEnd()
    {
        carController.RaceEnd();
    }

    public void Pause()
    {
        carController.Pause();
    }

    public void PauseCancel()
    {
        carController.PauseCancel();
    }
}
