using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    private AudioSource audioSourceBGM;

    private AudioMixer audioMixer;

    private AudioMixerGroup MasterMixer;

    private AudioMixerGroup BGMMixer;
    private AudioMixerGroup SFXMixer;

    private IAudioRepository audioRepository;

    public void Inject(IAudioRepository audioRepository , AudioMixer audioMixer)
    {
        this.audioRepository = audioRepository;
        this.audioMixer = audioMixer;
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
        audioSourceBGM = GetComponentInChildren<AudioSource>();
    }

    private void Start()
    {
        MasterMixer = audioMixer.FindMatchingGroups("Master")[0];
        BGMMixer = audioMixer.FindMatchingGroups("BGM")[0];
        SFXMixer = audioMixer.FindMatchingGroups("SFX")[0];
        audioSourceBGM.outputAudioMixerGroup = BGMMixer;
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
        audioSource.outputAudioMixerGroup = SFXMixer;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopSFX(AudioSource audioSource)
    {
        audioSource.Stop();
    }

    public void SetMixer(string mixName,float Value)
    {
        if(Value == 0)
        {
            Value = 0.001f;
        }

        Value = Mathf.Lerp(-24, 20,Value);
        audioMixer.SetFloat(mixName, Value);
    }

}
