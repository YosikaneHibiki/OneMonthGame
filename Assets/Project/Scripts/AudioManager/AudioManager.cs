using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    private AudioSource audioSourceBGM;

    private IAudioRepository audioRepository;

    public void Inject(IAudioRepository audioRepository)
    {
        this.audioRepository = audioRepository;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        audioSourceBGM = GetComponentInChildren<AudioSource>();
    }

    public void PlayBGM(string bgmName)
    {
        var clip = audioRepository.FindBGM(bgmName);
        audioSourceBGM.clip = clip;
        audioSourceBGM.Play();
    }

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PitchChange(float pitch)
    {
        audioSourceBGM.pitch = pitch;
    }

    public void VolumeChange(float Volume)
    {
        audioSourceBGM.volume = Volume;
    }

    public void PitchChange(AudioSource audioSource, float AudioPitch)
    {
        audioSource.pitch = AudioPitch;
    }
    public void VolumeChange(AudioSource source, float Volume)
    {
        source.volume = Volume;
    }

    public void PlaySFX(string sfxName, AudioSource audioSource)
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
