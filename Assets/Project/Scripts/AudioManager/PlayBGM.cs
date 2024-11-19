using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour , IRaceStart
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    public void RaceStart()
    {
        Debug.Log("Play");
        audioManager.PlayBGM("initialD BGM");
    }
}
