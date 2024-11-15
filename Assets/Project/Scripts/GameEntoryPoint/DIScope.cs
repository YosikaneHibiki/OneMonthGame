using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class DIScope : MonoBehaviour
{
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken cancellationToken;
    private RaceDomain raceDomain;
    private CarDataAccess carDataAccess;

    private IEnumerable<IGameEnd> gameEnds;

    [SerializeField]
    private CarController carController;
    [SerializeField]
    private GoalPoint goalPoint = new();
    [SerializeField]
    private RacePresenter racePresenter;
    [SerializeField]
    private CarDataBase carDataBase;
    [SerializeField]
    private RaceManager raceManager;

    private void Awake()
    {
        DIContainer();
    }

    public void DIContainer()
    {

        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
        #region DI専用コンテナ
        carDataAccess = new(carDataBase);
        raceDomain = new(cancellationToken, racePresenter, carController, gameEnds);
        carController.Inject(carDataAccess);
        goalPoint.Inject(raceDomain);
        raceManager.Inject(raceDomain, raceDomain);
        #endregion
    }

    private void OnDestroy()
    {
        cancellationTokenSource.Cancel();
    }


}
