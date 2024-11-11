using UnityEngine;
using UnityEngine.UI;

public class Wheel_UI : MonoBehaviour
{
    [SerializeField]
    private Image WheelImage;
    [SerializeField]
    private WheelController WheelController;

    private void Update()
    {
        WheelImage.color = new Color(WheelController.SlipValue,0,0);
    }
}
