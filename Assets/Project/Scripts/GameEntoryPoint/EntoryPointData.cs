using MackySoft.Navigathena.SceneManagement;
using UnityEngine.Audio;

public class EntoryPointData : ISceneData
{
    public readonly string carId;
    public readonly AudioMixer audioMixer;
    public EntoryPointData(string carId,AudioMixer audioMixer = null)
    {
        this.carId = carId;
        this.audioMixer = audioMixer;
    }
}
