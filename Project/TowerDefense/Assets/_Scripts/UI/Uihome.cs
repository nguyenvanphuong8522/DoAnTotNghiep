using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uihome : Singleton<Uihome>
{
    public ButtonEffectLogic btnPlay;
    public ButtonEffectLogic btnSetting;
    public PopUpManager popUpManager;

    protected override void Awake()
    {
        btnPlay.onClick.AddListener(ShowPopUpLevel);
        btnSetting.onClick.AddListener(ShowPopUpSetting);
        base.Awake();
    }
    private void ShowPopUpLevel()
    {
        popUpManager.popUpLevel.Show();
    }
    private void ShowPopUpSetting()
    {
        popUpManager.popupSetting.Show();
    }

    public void HideHome()
    {
        gameObject.SetActive(false);
    }
}
