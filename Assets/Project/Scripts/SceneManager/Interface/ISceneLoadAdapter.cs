using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneLoadAdapter
{
    void SceneLoad(string sceneName);
    void SceneReLoad();
}
