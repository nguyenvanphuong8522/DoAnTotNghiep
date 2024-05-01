using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uihome : Singleton<Uihome>
{
    public ButtonEffectLogic btnPlay;
    public ButtonEffectLogic btnSetting;
    public PopUpManager popUpManager;
    private void Start()
    {
        btnPlay.onClick.AddListener(ShowPopUpLevel);
        btnSetting.onClick.AddListener(ShowPopUpSetting);
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
        UiGameplay.instance.Show();
        gameObject.SetActive(false);
    }
    public void ShowHome()
    {
        gameObject.SetActive(true);
        UiGameplay.instance.Hide();
    }
}
