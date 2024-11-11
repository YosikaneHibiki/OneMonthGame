using System.Threading;
using UnityEngine;

public class RacePresenter : MonoBehaviour, IRaceOutput
{
    [SerializeField]
    private GameRadeyPresenter radeyPresenter;
    [SerializeField]
    private GameGoalPresenter goalPresenter;

    public void RadeyOutput(CancellationToken token)
    {
        radeyPresenter.Readey(token);
    }

    public void StartOutput(CancellationToken token)
    {

    }

    public void GoaleOutput(CancellationToken token)
    {
        goalPresenter.GoalPresenter();
    }


}
