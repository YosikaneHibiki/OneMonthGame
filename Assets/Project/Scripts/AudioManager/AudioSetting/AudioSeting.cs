using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSeting : MonoBehaviour
{
    [SerializeField]
    private Slider MasterSlider;
    [SerializeField]
    private Slider SFXSlider;
    [SerializeField]
    private Slider BGMSlider;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        audioManager.SetMixer("Master", MasterSlider.value);
        audioManager.SetMixer("SFX", SFXSlider.value);
        audioManager.SetMixer("BGM", BGMSlider.value);
    }

    private void Update()
    {
        audioManager.SetMixer("Master",MasterSlider.value);
        audioManager.SetMixer("SFX",SFXSlider.value);
        audioManager.SetMixer("BGM",BGMSlider.value);
    }

}
