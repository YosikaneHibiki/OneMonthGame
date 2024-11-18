using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameGoalPresenter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text goalText;
    [SerializeField]
    private Button titleButton;
    private SceneLoadGate loadGate;

    private void Start()
    {
        loadGate = SceneLoadGate.Instance;
    }

    public async void GameGoal(CancellationToken token)
    {
        goalText.text = "GOAL";
        titleButton.onClick.AddListener(LoadTitleScene);
        await UniTask.Delay(TimeSpan.FromSeconds(1),cancellationToken: token);
        titleButton.gameObject.SetActive(true);
    }

    public void LoadTitleScene()
    {
        loadGate.SceneLoad("TitleScene");
    }

}
