using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SelectTimeAttack : MonoBehaviour
{
    private CarID carID;
    private SceneLoadGate sceneLoadGate;
    private SceneID sceneName;
    [SerializeField]
    private AudioMixer audioMixer;


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
        sceneLoadGate = SceneLoadGate.Instance;
        sceneLoadGate.SceneLoadProgress(sceneName.id,"LoadScene",new EntoryPointData(carID.id,audioMixer));
    }
}
