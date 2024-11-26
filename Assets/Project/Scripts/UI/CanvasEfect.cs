using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;

public class CanvasEfect : MonoBehaviour
{

    private CancellationToken token;

    public void Inject(CancellationToken token)
    {
        this.token = token;
    }



    public async void OpenEfect(CanvasGroup menuUI)
    {
        menuUI.gameObject.SetActive(true);
        await menuUI.DOFade(1, 0.5f)
            .SetEase(Ease.OutCubic).ToUniTask(cancellationToken: token);
    }

    public async void CloseEfect(CanvasGroup menuUI)
    {
        await menuUI.DOFade(0, 0.5f)
            .SetEase(Ease.OutCubic).ToUniTask(cancellationToken: token);
        menuUI.gameObject.SetActive(false);
    }
}
