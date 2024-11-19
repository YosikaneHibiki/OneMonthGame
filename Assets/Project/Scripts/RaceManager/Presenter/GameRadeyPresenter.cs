using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameRadeyPresenter : MonoBehaviour
{

    [SerializeField]
    private TMP_Text countDownText;

    public async UniTask Readey(CancellationToken token)
    {
        countDownText.text = "Radey";
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        countDownText.text = "3";
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        countDownText.text = "2";
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        countDownText.text = "1";
        await UniTask.Delay(TimeSpan.FromSeconds(0.4f), cancellationToken: token);
        countDownText.text = "Go";
        await UniTask.Delay(TimeSpan.FromSeconds(0.4f));
        countDownText.enabled = false;
    }

}
