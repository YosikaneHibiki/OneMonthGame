using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDIScope : MonoBehaviour
{
    private SceneLoadNavi sceneLoadNavi;
    [SerializeField]
    private SceneLoadGate SceneLoadGate;

    private void Awake()
    {
        sceneLoadNavi = new SceneLoadNavi();
        SceneLoadGate.Inject(sceneLoadNavi);
    }
}
