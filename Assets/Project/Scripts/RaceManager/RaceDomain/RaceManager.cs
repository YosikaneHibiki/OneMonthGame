using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class RaceManager : MonoBehaviour
{

    public static RaceManager Instance;
    private IRaceInput raceInput;
    private ICheckpoint checkpoint;


    public void Inject(IRaceInput raceInput,ICheckpoint checkpoint)
    { 
        this.raceInput = raceInput;
        this.checkpoint = checkpoint;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        raceInput.GameRadey();
    }

    public void RaceStart()
    {
        raceInput.RaceStart();
    }

    public void RaceGoal()
    {
        raceInput.RaceGoal();
    }

    public void CarReset()
    {
        raceInput.GameReset();
    }

    public void Checkpoint(CheckPointData checkPointData)
    {
        checkpoint.CheckPoint(checkPointData);
    }

}
