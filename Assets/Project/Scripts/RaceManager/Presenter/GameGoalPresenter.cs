using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;

public class GameGoalPresenter : MonoBehaviour
{
    [SerializeField]
    private CarController carController;

    [SerializeField]
    private TMP_Text goalText;

    public void GoalPresenter()
    {
        goalText.text = "GOAL";
        carController.gameType = GameType.Goal;
        UniTask.Delay(TimeSpan.FromSeconds(1.5));
        goalText.text = "Time" + Time.time;
    }

}
