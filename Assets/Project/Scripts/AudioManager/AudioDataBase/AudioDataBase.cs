using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AudioData",menuName = "Data/AudioData")]
public class AudioDataBase : ScriptableObject
{
    public AudioClip[] BGM;
    public AudioClip[] SFX;
}
