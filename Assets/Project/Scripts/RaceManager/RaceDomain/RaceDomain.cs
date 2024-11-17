using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RaceDomain : IRaceInput, ICheckpoint
{
    private int CheckPointCount;
    private List<CheckPointData> Checkpoints = new();
    private IRaceOutput raceOutput;
    private IResetPostion resetPostion;
    private List<IRaceReady> raceRadeys;
    private List<IRaceStart> raceStarts;
    private List<IRaceEnd> raceEnds;
    private CancellationToken token;

    public RaceDomain(CancellationToken token, IRaceOutput raceOutput,
        IResetPostion resetPostion, List<IRaceReady> raceReadeys
        , List<IRaceStart> raceStarts, List<IRaceEnd> raceEnds)
    {
        this.raceOutput = raceOutput;
        this.resetPostion = resetPostion;
        this.token = token;
        this.raceRadeys = raceReadeys;
        this.raceStarts = raceStarts;
        this.raceEnds = raceEnds;
    }

    public void GameRadey()
    {
        Debug.Log("Radey");
        Time.timeScale = 1;
        foreach (var race in raceRadeys)
        {
            race.RaceReadey();
        }

        raceOutput.RadeyOutput(token);
    }

    public void RaceStart()
    {
        Debug.Log("Start");
        foreach (var race in raceStarts)
        {
            race.RaceStart();
        }
        raceOutput.StartOutput(token);
    }

    public void RaceGoal()
    {
        foreach (var race in raceEnds)
        {
        Debug.Log("GameEnd‚©‚©‚Á‚½ŽžŠÔ‚Í");
            race.RaceEnd();
        }
        raceOutput.GoaleOutput(token);
    }

    public void CheckPoint(CheckPointData checkPointData)
    {
        CheckPointCount++;
        Checkpoints.Add(checkPointData);
        if (checkPointData.CheckPointNumber != CheckPointCount)
        {
            CheckPointCount--;
            resetPostion.ResetPostion(Checkpoints[CheckPointCount - 1]);
            Checkpoints.Remove(checkPointData);
        }
    }

    public void GameReset()
    {
        resetPostion.ResetPostion(Checkpoints[CheckPointCount - 1]);
    }
}
