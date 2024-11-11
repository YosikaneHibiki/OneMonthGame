using System.Threading;
using UnityEngine;

public class DIScope : MonoBehaviour
{
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken cancellationToken;
    private RaceDomain raceDomain;
    private CarDataAccess carDataAccess;

    [SerializeField]
    private CarController carController;
    [SerializeField]
    private GoalPoint goalPoint;
    [SerializeField]
    private RacePresenter racePresenter;
    [SerializeField]
    private CarDataBase carDataBase;

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
        raceDomain = new(cancellationToken, racePresenter);
        carController.Inject(raceDomain,carDataAccess);
        goalPoint.Inject(raceDomain);
        #endregion
    }

    private void OnDestroy()
    {
        cancellationTokenSource.Cancel();
    }


}
