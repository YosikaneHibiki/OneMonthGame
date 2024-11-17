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

    public void SceneReLoad()
    {
        sceneLoad.SceneReLoad();
    }


}
