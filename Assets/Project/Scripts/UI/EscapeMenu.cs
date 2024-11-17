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

    private void Start()
    {
        sceneLoadGate  = SceneLoadGate.Instance;
        ContinueButton.onClick.AddListener(Continue);
        ResetButton.onClick.AddListener(ReStart);
    }

    public void OpenMenu()
    {
        if(this.gameObject.activeSelf == false)
        {
            gameManager.Pause();
            this.gameObject.SetActive(true);
        }
        else
        {
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

    }




}
