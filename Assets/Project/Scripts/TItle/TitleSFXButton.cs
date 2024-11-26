using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSFXButton : MonoBehaviour
{
    private AudioManager audioManager;
    private AudioSource audioSource;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickSFXPlay()
    {
        audioManager.PlaySFX("OpenUISFX", audioSource);
    }
}
