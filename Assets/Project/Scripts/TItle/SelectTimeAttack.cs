using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTimeAttack : MonoBehaviour
{
    [SerializeField]
    private CarID carID;
    private SceneLoadGate sceneLoadGate;
    private SceneID sceneName;

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
        sceneLoadGate.SceneLoadProgress(sceneName.id,"LoadScene",carID);
    }
}
