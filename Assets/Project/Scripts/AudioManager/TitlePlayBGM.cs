using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayBGM : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        audioManager.PlayBGM("owl-forest-1");
    }
}
