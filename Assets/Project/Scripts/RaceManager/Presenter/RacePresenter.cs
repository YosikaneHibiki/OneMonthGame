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
    private RaceManager raceManager;

    public async void RadeyOutput(CancellationToken token)
    {
        try
        {
        await radeyPresenter.Readey(token);
        }
        catch(OperationCanceledException e){}
        raceManager.RaceStart();
    }

    public void StartOutput(CancellationToken token)
    {
        startPresenter.GameStart();
    }

    public void GoaleOutput(CancellationToken token)
    {
        goalPresenter.GameGoal(token);
    }


}
