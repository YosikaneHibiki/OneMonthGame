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
        await radeyPresenter.Readey(token);
        raceManager.GameStart();
    }

    public void StartOutput(CancellationToken token)
    {
        controller.gameType = GameType.Start;
        startPresenter.GameStart();
    }

    public void GoaleOutput(CancellationToken token)
    {
        startPresenter.GameGoal();
        controller.gameType = GameType.Goal;
        goalPresenter.GoalPresenter();
    }


}
