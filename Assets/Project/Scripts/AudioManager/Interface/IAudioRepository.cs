using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioRepository
{
    AudioClip FindSFX(string sfxName);
    AudioClip FindBGM(string bgmName);
}
