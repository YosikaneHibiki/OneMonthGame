using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    [SerializeField]
    private RaceManager raceManager;
    private Button resetButton;

    private void Start()
    {
        resetButton = GetComponent<Button>();
        resetButton.onClick.AddListener(CarRestButton);
    }

    private void CarRestButton()
    {
        raceManager.CarReset();
    }
}
