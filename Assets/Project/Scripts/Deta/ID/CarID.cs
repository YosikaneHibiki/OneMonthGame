using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New CarId", menuName = "Data/Car/CarID")]
public class CarID : BaseID
{
    public string id;

    public override string Id => id;

    public override IDType IDType => IDType.CarID;  

    public void OnValidate()
    {
#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
#endif
    }
}
