using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIContller : MonoBehaviour
{

    [SerializeField]
    private CanvasEfect canvasEfect;
    private AudioManager audioManager;
    private AudioSource audioSource;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    public void MenuActive(CanvasGroup OpenGroup,CanvasGroup CloseGroup)
    {
        audioManager.PlaySFX("OpenUISFX", audioSource);
        canvasEfect.CloseEfect(CloseGroup);
        canvasEfect.OpenEfect(OpenGroup);
    }

    public void MenuClose(CanvasGroup OpenGroup,CanvasGroup CloseGroup)
    {
        audioManager.PlaySFX("CloseUISFX", audioSource);
        canvasEfect.OpenEfect(OpenGroup);
        canvasEfect.CloseEfect(CloseGroup);
    }

}
