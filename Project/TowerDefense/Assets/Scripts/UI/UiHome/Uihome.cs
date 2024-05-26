using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uihome : Singleton<Uihome>
{
    public ButtonEffectLogic btnPlay;
    public ButtonEffectLogic btnSetting;
    public ButtonEffectLogic btnInforGame;
    public PopUpManager popUpManager;

    public Sprite spriteGray;
    public Sprite spriteGreen;
    private void Start()
    {
        Loading.instance.Show();
        btnPlay.onClick.AddListener(ShowPopUpLevel);
        btnSetting.onClick.AddListener(ShowPopUpSetting);
        btnInforGame.onClick.AddListener(ShowPopUpInforGame);
    }
    private void ShowPopUpLevel()
    {
        popUpManager.popUpLevel.Show();
    }
    private void ShowPopUpSetting()
    {
        popUpManager.popupSetting.Show();
    }
    private void ShowPopUpInforGame()
    {
        popUpManager.popupInforGame.Show();
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
