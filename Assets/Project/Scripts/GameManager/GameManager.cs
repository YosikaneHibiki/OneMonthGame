using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<IRacePause> racePauses;

    public static GameManager Instance;
    public bool isMenuOpen;

    public void Inject(List<IRacePause> racePauses)
    {
        this.racePauses = racePauses;
    }

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isMenuOpen = true;
        foreach(var racePauses in racePauses)
        {
            racePauses.Pause();
        }
    }
    public void PauseCancel()
    {
        Time.timeScale = 1f;
        isMenuOpen = false;
        foreach (var racePauses in racePauses)
        {
            racePauses.PauseCancel();
        }
    }
}
