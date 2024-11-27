using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUIButton : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup openGroup;
    [SerializeField]
    private CanvasGroup closeGroup;
    [SerializeField]
    private TitleUIContller titleUIContller;

    public void OpenMenu()
    {
        titleUIContller.MenuActive(openGroup,closeGroup);
    }

    public void CloseMenu()
    {
        titleUIContller.MenuClose(openGroup,closeGroup);
    }
}
