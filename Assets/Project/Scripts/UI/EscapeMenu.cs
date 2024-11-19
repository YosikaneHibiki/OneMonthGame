using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Button ContinueButton;
    [SerializeField]
    private Button ResetButton;
    [SerializeField]
    private Button QuitButton;

    private SceneLoadGate sceneLoadGate;
    private AudioManager audioManager;

    private void Awake()
    {
        sceneLoadGate  = SceneLoadGate.Instance;
        audioManager = AudioManager.Instance;
        ContinueButton.onClick.AddListener(Continue);
        ResetButton.onClick.AddListener(ReStart);
        QuitButton.onClick.AddListener(Quit);
    }

    public void OpenMenu()
    {
        if(this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
            gameManager.Pause();
            audioManager.VolumeChange(0.3f);
        }
        else
        {
            audioManager.VolumeChange(1);
            Continue();
        }
    }

    private void Continue()
    {
        if(this.gameObject.activeSelf)
        {
            gameManager.PauseCancel();
            this.gameObject.SetActive(false);
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




}
