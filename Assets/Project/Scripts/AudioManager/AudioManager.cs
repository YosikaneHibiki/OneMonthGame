using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private IAudioRepository audioRepository;

    public void Inject(IAudioRepository audioRepository)
    {
        this.audioRepository = audioRepository;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayBGM(AudioSource audioSource,string bgmName)
    {
        var clip = audioRepository.FindBGM(bgmName);
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    public void PitchChange(AudioSource audioSource, float AudioPitch)
    {
        audioSource.pitch = AudioPitch;
    }
    public void VolumeChange(AudioSource source, float Volume)
    {
        source.volume = Volume;
    }

    public void PlaySFX(string sfxName,AudioSource audioSource)
    {
        var clip = audioRepository.FindSFX(sfxName);
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopSFX(AudioSource audioSource)
    {
        audioSource.Stop();
    }

}
