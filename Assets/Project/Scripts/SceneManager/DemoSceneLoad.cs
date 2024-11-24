using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSceneLoad : MonoBehaviour
{
    private SceneLoadGate SceneLoadGate;
    [SerializeField]
    private CarID carID;

    public void Start()
    {
        SceneLoadGate = SceneLoadGate.Instance;
    }

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneLoadGate.SceneLoad("NextScne");
        }
    }

}
