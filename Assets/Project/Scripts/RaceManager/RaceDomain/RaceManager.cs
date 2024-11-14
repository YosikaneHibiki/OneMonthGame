using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class RaceManager : MonoBehaviour
{ 
    private IRaceInput raceInput;
    private ICheckpoint checkpoint;

    public void Inject(IRaceInput raceInput,ICheckpoint checkpoint)
    { 
        this.raceInput = raceInput;
        this.checkpoint = checkpoint;
    }

    private void Start()
    {
        raceInput.GameRadey();
    }

    public void GameStart()
    {
        raceInput.GameStart();
    }

    public void GameEnd()
    {
        
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
