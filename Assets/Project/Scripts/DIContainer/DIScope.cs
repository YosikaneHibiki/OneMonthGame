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
    private CarController carController;
    [SerializeField]
    private RacePresenter racePresenter;
    [SerializeField]
    private CarDataBase carDataBase;
    [SerializeField]
    private RaceManager raceManager;
    [SerializeField]
    private SceneLoadGate sceneLoadGate;
    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private AudioDataBase audioDataBase;
    [SerializeField]
    private GameManager gameManager;

    private void Awake()
    {
        raceReady = FindObjectsOfType<MonoBehaviour>().OfType<IRaceReady>();
        raceStart = FindObjectsOfType<MonoBehaviour>().OfType<IRaceStart>();
        raceEnd = FindObjectsOfType<MonoBehaviour>().OfType<IRaceEnd>();
        racePause = FindObjectsOfType<MonoBehaviour>().OfType<IRacePause>();
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
        DIContainer();
    }

    public void DIContainer()
    {
        #region DI専用コンテナ
        audioDataAccess = new(audioDataBase);
        carDataAccess = new CarDataAccess(carDataBase);
        sceneLoad = new SceneLoadUnity();
        raceDomain = new RaceDomain(cancellationToken, racePresenter, 
        carController,raceReady.ToList(),raceStart.ToList(),raceEnd.ToList());
        sceneLoadGate.Inject(sceneLoad);
        carController.Inject(carDataAccess);
        raceManager.Inject(raceDomain, raceDomain);
        audioManager.Inject(audioDataAccess);
        gameManager.Inject(racePause.ToList());
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
