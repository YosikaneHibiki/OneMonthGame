using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDIScope : MonoBehaviour
{
    private SceneLoadUnity sceneLoadUnity;
    [SerializeField]
    private SceneLoadGate SceneLoadGate;

    private void Awake()
    {
        sceneLoadUnity = new SceneLoadUnity();
        SceneLoadGate.Inject(sceneLoadUnity);
    }
}
