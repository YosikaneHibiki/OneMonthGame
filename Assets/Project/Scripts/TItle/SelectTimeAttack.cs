using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTimeAttack : MonoBehaviour
{
    private SceneLoadGate sceneLoadGate;

    public void LoadTimeAttack()
    {
        sceneLoadGate = SceneLoadGate.Instance;
        sceneLoadGate.SceneLoad("RaceTrack");
    }
}
