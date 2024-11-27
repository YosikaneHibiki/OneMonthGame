using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameRadeyPresenter : MonoBehaviour
{

    private AudioManager audioManager;
    private AudioSource audioSource;

    [SerializeField]
    private TMP_Text countDownText;

    public async UniTask Readey(CancellationToken token)
    {
        audioManager = AudioManager.Instance;
        audioSource = GetComponent<AudioSource>();
        audioManager.PlayBGM("stationair-77179");
        countDownText.text = "Radey";
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        countDownText.text = "3";
        audioManager.PlaySFX("short-beep-tone-47916", audioSource);
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        countDownText.text = "2";
        audioManager.PlaySFX("short-beep-tone-47916", audioSource);
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        countDownText.text = "1";
        audioManager.PlaySFX("short-beep-tone-47916", audioSource);
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        countDownText.text = "Go";
        audioManager.PlaySFX("logarithm-out-square-wave-beep-102963", audioSource);
        await UniTask.Delay(TimeSpan.FromSeconds(0.4f));
        countDownText.enabled = false;
    }

}
