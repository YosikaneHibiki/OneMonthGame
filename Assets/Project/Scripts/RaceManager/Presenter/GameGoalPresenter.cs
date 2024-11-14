using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;

public class GameGoalPresenter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text goalText;

    public void GameGoal()
    {
        goalText.text = "GOAL";
    }

}
