using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPreview : BasePopup
{
    [SerializeField] private LitsElementActive listElement;
    [SerializeField] private int index;
    [SerializeField] private ButtonEffectLogic btnStart;
    [SerializeField] private Text txtMission;
    [SerializeField] private Image mapPreview;
    private void Start()
    {
        btnStart.onClick.AddListener(StartButton);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        index = (int)data;
        SetList();
    }
    private void SetList()
    {
        listElement.SetListElement(index);
        SetTxtMission();
        SetMapPreview();
    }
    public void StartButton()
    {
        Uihome.instance.HideHome();
        LevelManager.instance.InitLevel(index);
        Hide();
    }
    private void SetTxtMission()
    {
        txtMission.text = "Mission " + (index + 1);
    }
    private void SetMapPreview()
    {
        mapPreview.sprite =  LevelManager.instance.listLevelData.levels[index].screenMap;
    }
}
