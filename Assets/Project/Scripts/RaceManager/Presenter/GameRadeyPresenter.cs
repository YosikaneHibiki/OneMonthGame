using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameRadeyPresenter : MonoBehaviour
{
    [SerializeField]
    private CarController carController;
    [SerializeField]
    private TMP_Text countDownText;

    public async void Readey(CancellationToken token)
    {
        carController.gameType = GameType.Radey;
        countDownText.text = "Radey";
        await UniTask.Delay(TimeSpan.FromSeconds(1),cancellationToken : token);
        countDownText.text = "3";
        await UniTask.Delay(TimeSpan.FromSeconds(1),cancellationToken : token);
        countDownText.text = "2";
        await UniTask.Delay(TimeSpan.FromSeconds(1),cancellationToken : token);
        countDownText.text = "1";
        await UniTask.Delay(TimeSpan.FromSeconds(1),cancellationToken : token);
        countDownText.text = "Go";
        carController.gameType = GameType.Start;
        await UniTask.Delay(TimeSpan.FromSeconds(0.4));
        countDownText.enabled = false;
    }

}
