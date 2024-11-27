using Cysharp.Threading.Tasks;
using MackySoft.Navigathena;
using MackySoft.Navigathena.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class DIScope : SceneEntryPointBase
{
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken cancellationToken;
    private RaceDomain raceDomain;
    private CarDataAccess carDataAccess;
    private SceneLoadNavi loadNavi;
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
    private string carID;

    private AudioMixer audioMixer;

    private void Seting()
    {
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
        raceReady = FindObjectsOfType<MonoBehaviour>().OfType<IRaceReady>();
        raceStart = FindObjectsOfType<MonoBehaviour>().OfType<IRaceStart>();
        raceEnd = FindObjectsOfType<MonoBehaviour>().OfType<IRaceEnd>();
        racePause = FindObjectsOfType<MonoBehaviour>().OfType<IRacePause>();
        DIContainer();
        raceStartPoint.CreateCar(new(carID));
        raceManager.GameRadey();
    }

    public void DIContainer()
    {
        #region DI専用コンテナ
        audioDataAccess = new(audioDataBase);
        carDataAccess = new CarDataAccess(carDataBase);
        loadNavi = new SceneLoadNavi();
        raceDomain = new RaceDomain(cancellationToken, racePresenter,
        carReset, raceReady.ToList(), raceStart.ToList(), raceEnd.ToList());
        sceneLoadGate.Inject(loadNavi);
        raceManager.Inject(raceDomain, raceDomain);
        audioManager.Inject(audioDataAccess, audioMixer);
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

    protected override UniTask OnInitialize(ISceneDataReader reader, IProgress<IProgressDataStore> progress, CancellationToken cancellationToken)
    {
        if (reader.TryRead(out EntoryPointData entoryPointData))
        {
            carID = entoryPointData.carId;
            audioMixer = entoryPointData.audioMixer;
        }
        Seting();

        return base.OnInitialize(reader, progress, cancellationToken);
    }
}
