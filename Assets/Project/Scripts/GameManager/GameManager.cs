using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void PauseCancel()
    {
        Time.timeScale = 1f;
    }
}
