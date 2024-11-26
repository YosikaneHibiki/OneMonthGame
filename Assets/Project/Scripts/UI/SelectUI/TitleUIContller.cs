using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIContller : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup menuActive;
    [SerializeField]
    private CanvasGroup titleMenu;
    [SerializeField]
    private CanvasEfect canvasEfect;
    private AudioManager audioManager;
    private AudioSource audioSource;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    public void MenuActive()
    {
        audioManager.PlaySFX("OpenUISFX", audioSource);
        canvasEfect.CloseEfect(titleMenu);
        canvasEfect.OpenEfect(menuActive);
    }

    public void MenuClose()
    {
        audioManager.PlaySFX("CloseUISFX", audioSource);
        canvasEfect.OpenEfect(titleMenu);
        canvasEfect.CloseEfect(menuActive);
    }

}
