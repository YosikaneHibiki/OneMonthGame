using TMPro;
using UnityEngine;

public class GameStartPresenter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TimerText;
    private float Timer;
    private bool isGameStart;

    public void GameStart()
    {
        Timer = Time.time;
        isGameStart = true;
    }

    public void GameGoal()
    {
        isGameStart=false;
    }

    public void Update()
    {
        if (!isGameStart)
        {
            return;
        }
        var time = Time.time - Timer;
        TimerText.text = time.ToString();
    }

}
