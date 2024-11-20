using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour , IRacePause
{

    [SerializeField]
    private Button ContinueButton;
    [SerializeField]
    private Button ResetButton;
    [SerializeField]
    private Button QuitButton;
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameManager gameManager;
    private SceneLoadGate sceneLoadGate;
    private AudioManager audioManager;

    private void Start()
    {
        sceneLoadGate = SceneLoadGate.Instance;
        gameManager = GameManager.Instance;
        audioManager = AudioManager.Instance;
        ContinueButton.onClick.AddListener(Continue);
        ResetButton.onClick.AddListener(ReStart);
        QuitButton.onClick.AddListener(Quit);
    }


    private void Continue()
    {
        if(this.gameObject.activeSelf)
        {
            gameManager.PauseCancel();
            menu.SetActive(false);
        }
    }

    private void ReStart()
    {
        sceneLoadGate.SceneReLoad();
    }

    private void Quit()
    {
        sceneLoadGate.SceneLoad("TitleScene");
    }

    public void Pause()
    {
        Debug.Log("Pause");
        menu.SetActive(true);
        audioManager.VolumeChange(0.3f);
    }

    public void PauseCancel()
    {
        Debug.Log("UnPause");
        audioManager.VolumeChange(1);
        menu.SetActive(false);
    }
}
