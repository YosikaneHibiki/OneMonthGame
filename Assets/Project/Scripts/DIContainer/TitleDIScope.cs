using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class TitleDIScope : MonoBehaviour
{
    private SceneLoadNavi sceneLoadNavi;
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken token;
    private AudioDataAccess audioDataAccess;

    [SerializeField]
    private SceneLoadGate SceneLoadGate;
    [SerializeField]
    private CanvasEfect canvasEfect;
    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private AudioDataBase audioDataBase;
    [SerializeField]
    private AudioMixer audioMixer;

    public void Awake()
    {
        cancellationTokenSource = new CancellationTokenSource();
        token = cancellationTokenSource.Token;
        audioDataAccess = new AudioDataAccess(audioDataBase);
        sceneLoadNavi = new SceneLoadNavi();
        audioManager.Inject(audioDataAccess,audioMixer);
        SceneLoadGate.Inject(sceneLoadNavi);
        canvasEfect.Inject(token);
    }

    public void Disable()
    {
        cancellationTokenSource.Cancel();
        cancellationTokenSource?.Dispose();
        cancellationTokenSource=null;
    }

}
