using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New SceneID",menuName = "Data/SceneID")]
public class SceneID : BaseID
{
    public string id;

    public override string Id => id;

    public override IDType IDType => IDType.SceneID;

    public void OnValidate()
    {
//#if UNITY_EDITOR
//        id = Scene.name;
//#endif
    }
}
