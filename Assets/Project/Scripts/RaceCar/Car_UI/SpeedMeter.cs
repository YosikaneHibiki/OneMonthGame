using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour ,IRaceEnd
{
    [SerializeField]
    private RectTransform arrow;
    [SerializeField]
    private CarController carController;

    [SerializeField]
    private float minMeterRotation;
    [SerializeField]
    private float maxMeterRotation;
    [SerializeField]
    private float currentMeterRotation;

    [SerializeField]
    private TMP_Text text;


    public void RaceEnd()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        int speedText =Mathf.RoundToInt(carController.speed);
        text.text = speedText.ToString() ;
        arrow.localEulerAngles = new Vector3( 0, 0, Mathf.Lerp(minMeterRotation, maxMeterRotation, carController.speed / carController.MaxSpeed));
    }

}
