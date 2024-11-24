using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectService : MonoBehaviour
{
    [SerializeField]
    private SelectTimeAttack timeAttack;

    public void SetCarID(CarID carID)
    {
        timeAttack.SetCarData(carID);
    }

    public void SetStage(SceneID sceneID)
    {
        timeAttack.SetSceneName(sceneID);
    }

}
