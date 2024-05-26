using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPreview : BasePopup
{
    [SerializeField] private LitsElementActive listElement;
    [SerializeField] private int index;
    [SerializeField] private ButtonEffectLogic btnStart;
    private void OnEnable()
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
    }
    public void StartButton()
    {
        Uihome.instance.HideHome();
        LevelManager.instance.InitLevel(index);
        Hide();
    }
}
