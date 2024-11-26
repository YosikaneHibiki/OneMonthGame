using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTimeAttack : MonoBehaviour
{
    private CarID carID;
    private SceneLoadGate sceneLoadGate;
    private SceneID sceneName;
    private AudioManager audioManager;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioManager = AudioManager.Instance;
    }

    public void SetCarData(BaseID carID)
    {
        this.carID = carID as CarID;
    }

    public void SetSceneName(BaseID sceneName)
    {
        this.sceneName = sceneName as SceneID;
    }

    public void LoadTimeAttack()
    {
        audioManager.PlaySFX("OpenUISFX", audioSource);
        sceneLoadGate = SceneLoadGate.Instance;
        sceneLoadGate.SceneLoadProgress(sceneName.id,"LoadScene",carID);
    }
}
