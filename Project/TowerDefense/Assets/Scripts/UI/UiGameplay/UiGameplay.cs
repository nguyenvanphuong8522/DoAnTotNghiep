using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGameplay : Singleton<UiGameplay>
{
    public BtnPause btnPause;
    public BtnSetting btnSetting;
    public BtnSpeedUp btnX2Speed;

    public PopupSettingInGame popUpSetting;

    protected override void Awake()
    {
        base.Awake();
        Hide();
    }

    private void ShowPopUpSetting()
    {
        popUpSetting.Show();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
