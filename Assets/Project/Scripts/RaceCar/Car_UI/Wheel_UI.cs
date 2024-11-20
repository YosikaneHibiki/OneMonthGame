using UnityEngine;
using UnityEngine.UI;

public class Wheel_UI : MonoBehaviour
{
    [SerializeField]
    private Image FLWheelImage;
    [SerializeField]
    private Image FRWheelImage;
    [SerializeField]
    private Image RLWheelImage;
    [SerializeField]
    private Image RRWheelImage;
    [SerializeField]
    private WheelController[] WheelControllers;

    public void InjectUI(WheelController[] wheelControllers)
    {
        this.WheelControllers = wheelControllers;
    }

    private void Update()
    {
        FLWheelImage.color = new Color(WheelControllers[0].SlipValue,0,0);
        FRWheelImage.color = new Color(WheelControllers[1].SlipValue,0,0);
        RLWheelImage.color = new Color(WheelControllers[2].SlipValue,0,0);
        RRWheelImage.color = new Color(WheelControllers[3].SlipValue,0,0);
    }
}
