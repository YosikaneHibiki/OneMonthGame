using System.Linq;
using UnityEngine;

public class AudioDataAccess : IAudioRepository
{
    public AudioDataBase dataBase;

    public AudioDataAccess(AudioDataBase audioDataBase)
    {
        dataBase = audioDataBase;
    }

    public AudioClip FindBGM(string bgmName)
    {
        var clip = dataBase.BGM
            .Where(audio => audio.name == bgmName)
            .FirstOrDefault();

        if (clip == null)
        {
            throw new System.Exception("audioClipÇ™ë∂ç›ÇµÇ»Ç¢");
        }

        return clip;
    }

    public AudioClip FindSFX(string sfxName)
    {
        var clip = dataBase.SFX
            .Where(audio => audio.name == sfxName)
            .FirstOrDefault();

        if (clip == null)
        {
            throw new System.Exception("audioClipÇ™ë∂ç›ÇµÇ»Ç¢");
        }
        return clip;
    }
}
