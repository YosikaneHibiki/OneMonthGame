using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    [SerializeField]
    private SelectData[] selectData;
    [SerializeField]
    private Image selectImage;
    [SerializeField]
    private Button LeftSelectButton;
    [SerializeField]
    private Button RightSelectButton;
    [SerializeField]
    private int SelectIndex;
    [SerializeField]
    private SelectTimeAttack timeAttack;
    [SerializeField]
    private TMP_Text selectText;

    [SerializeField]
    private Scene scene;

    private void Start()
    {
        SelectIndex = 0;
        ShowSelectUI();
        LeftSelectButton.onClick.AddListener(LeftSelect);
        RightSelectButton.onClick.AddListener(RightSelect);
    }

    public void LeftSelect()
    {
        SelectIndex--;
        ShowSelectUI();
    }

    public void RightSelect()
    {
        SelectIndex++;
        ShowSelectUI();
    }

    private void ShowSelectUI()
    {
        SelectIndex = Mathf.Clamp(SelectIndex, -1, selectData.Length);
        
        if(SelectIndex == -1)
        {
            SelectIndex = selectData.Length-1;
        }
        if(SelectIndex == selectData.Length)
        {
            SelectIndex = 0;
        }
        var showData = selectData[SelectIndex];
        selectImage.sprite = showData.selectSprite;
        selectText.text = showData.selectName;
        if(showData.id.IDType == IDType.CarID)
        {
            timeAttack.SetCarData(showData.id);
        }
        else if(showData.id.IDType == IDType.SceneID)
        {
            timeAttack.SetSceneName(showData.id);
        }
    }



}

