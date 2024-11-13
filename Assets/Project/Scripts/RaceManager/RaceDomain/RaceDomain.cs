using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RaceDomain : IRaceInput, ICheckpoint
{
    private int CheckPointCount;
    private List<CheckPointData> Checkpoints = new();
    private IRaceOutput raceOutput;
    private IResetPostion resetPostion;
    private CancellationToken token;

    public RaceDomain(CancellationToken token, IRaceOutput raceOutput, IResetPostion resetPostion)
    {
        this.raceOutput = raceOutput;
        this.resetPostion = resetPostion;
        this.token = token;
    }

    public void GameRadey()
    {
        Debug.Log("Radey");
        raceOutput.RadeyOutput(token);
    }

    public void GameStart()
    {
        Debug.Log("Start");
        raceOutput.StartOutput(token);
    }

    public void GameEnd()
    {
        Debug.Log("GameEnd‚©‚©‚Á‚½ŽžŠÔ‚Í");
        raceOutput.GoaleOutput(token);
    }

    public void CheckPoint(CheckPointData checkPointData)
    {
        CheckPointCount++;
        Checkpoints.Add(checkPointData);
        if (checkPointData.CheckPointNumber != CheckPointCount)
        {
            resetPostion.ResetPostion(Checkpoints[CheckPointCount -2].CheckPointPosition);
            Checkpoints.Remove(checkPointData);
        }
    }
}
