using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStart
{
    void Start();
}

public class RaceEntoryPoint : MonoBehaviour
{
    private List<IStart> starts = new List<IStart>();


    private void Awake()
    {
        RegsterEntoryPoint<Hoge>();
    }

    private void Start()
    {
        foreach (IStart start in starts)
        {
            start.Start();
        }
    }

    private void RegsterEntoryPoint<T>() where T : IStart ,new()
    {
        var entory = new T();
        starts.Add(entory);
    }

}

public class Hoge : IStart
{

    public void Start()
    {
        Debug.Log("スタート");
    }
}
