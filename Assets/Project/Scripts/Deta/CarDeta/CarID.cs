using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New CarId",menuName = "Data/Car/CarID")]
public class CarID : ScriptableObject
{
    public string Id;
    public void OnValidate()
    {
#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        Id = AssetDatabase.AssetPathToGUID(path);
#endif
    }
}
