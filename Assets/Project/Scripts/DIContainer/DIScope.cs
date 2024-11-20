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
    private SceneLoadUnity sceneLoad;
    private AudioDataAccess audioDataAccess;

    private IEnumerable<IRaceReady> raceReady;
    private IEnumerable<IRaceStart> raceStart;
    private IEnumerable<IRaceEnd> raceEnd;
    private IEnumerable<IRacePause> racePause;

    [SerializeField]
    private AudioDataBase audioDataBase;
    [SerializeField]
    private CarDataBase carDataBase;
    [SerializeField]
    private CarReset carReset;
    [SerializeField]
    private RacePresenter racePresenter;
    [SerializeField]
    private RaceManager raceManager;
    [SerializeField]
    private SceneLoadGate sceneLoadGate;
    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private RaceStartPoint raceStartPoint;
    [SerializeField]
    private RaceEntoryPoint raceEntoryPoint;

    private void Awake()
    {
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
        raceReady = FindObjectsOfType<MonoBehaviour>().OfType<IRaceReady>();
        raceStart = FindObjectsOfType<MonoBehaviour>().OfType<IRaceStart>();
        raceEnd = FindObjectsOfType<MonoBehaviour>().OfType<IRaceEnd>();
        racePause = FindObjectsOfType<MonoBehaviour>().OfType<IRacePause>();
        DIContainer();
        raceEntoryPoint.Entory();
    }

    public void DIContainer()
    {
        #region DI専用コンテナ
        audioDataAccess = new(audioDataBase);
        carDataAccess = new CarDataAccess(carDataBase);
        sceneLoad = new SceneLoadUnity();
        raceDomain = new RaceDomain(cancellationToken, racePresenter,
        carReset, raceReady.ToList(), raceStart.ToList(), raceEnd.ToList());
        sceneLoadGate.Inject(sceneLoad);
        raceManager.Inject(raceDomain, raceDomain);
        audioManager.Inject(audioDataAccess);
        gameManager.Inject(racePause.ToList());
        raceStartPoint.Inject(carDataAccess);
        #endregion
    }
    private void OnDestroy()
    {
        Debug.Log("削除");
        cancellationTokenSource?.Cancel();
        cancellationTokenSource?.Dispose();
        cancellationTokenSource = null;
    }
}
