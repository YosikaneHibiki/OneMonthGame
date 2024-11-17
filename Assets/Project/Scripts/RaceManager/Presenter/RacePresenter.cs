using System;
using System.Threading;
using UnityEngine;

public class RacePresenter : MonoBehaviour, IRaceOutput
{
    [SerializeField]
    private GameRadeyPresenter radeyPresenter;
    [SerializeField]
    private GameGoalPresenter goalPresenter;
    [SerializeField]
    private GameStartPresenter startPresenter;
    [SerializeField]
    private CarController controller;
    [SerializeField]
    private RaceManager raceManager;

    public async void RadeyOutput(CancellationToken token)
    {
        controller.gameType = GameType.Radey;
        try
        {
        await radeyPresenter.Readey(token);
        }
        catch(OperationCanceledException e){}
        raceManager.RaceStart();
    }

    public void StartOutput(CancellationToken token)
    {
        controller.gameType = GameType.Start;
        startPresenter.GameStart();
    }

    public void GoaleOutput(CancellationToken token)
    {
        goalPresenter.GoalPresenter();
    }


}
