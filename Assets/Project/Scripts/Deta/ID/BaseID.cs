using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IDType
{
    CarID,
    SceneID
}

public abstract class BaseID : ScriptableObject
{
    public abstract IDType IDType { get; }
    public abstract string Id { get; }
}
