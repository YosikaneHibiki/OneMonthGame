using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<IRacePause> racePauses;

    public void Inject(List<IRacePause> racePauses)
    {
        this.racePauses = racePauses;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        foreach(var racePauses in racePauses)
        {
            racePauses.Pause();
        }
    }
    public void PauseCancel()
    {
        Time.timeScale = 1f;
        foreach(var racePauses in racePauses)
        {
            racePauses.PauseCancel();
        }
    }
}
