using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadGate : MonoBehaviour
{
    public static SceneLoadGate Instance;

    private ISceneLoadAdapter sceneLoad;

    public void Inject(ISceneLoadAdapter sceneLoad)
    {
        this.sceneLoad = sceneLoad;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SceneLoad(string sceneName)
    {
        sceneLoad.SceneLoad(sceneName);
    }

    public void SceneLoad(string sceneName, CarID carID)
    {
        sceneLoad.SceneLoad(sceneName, carID);
    }

    public void SceneLoadProgress(string sceneName , string loadSceneName)
    {
        sceneLoad.SceneLoadProgress(sceneName,loadSceneName);
    }

    public void SceneLoadProgress(string sceneName , string loadSceneName,EntoryPointData entoryPointData)
    {
        sceneLoad.SceneLoadProgress(sceneName, loadSceneName, entoryPointData);
    }

    public void SceneReLoad()
    {
        sceneLoad.SceneReLoad();
    }


}
