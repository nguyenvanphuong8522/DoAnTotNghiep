using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGameplay : Singleton<UiGameplay>
{
    public BtnPause btnPause;
    public BtnSetting btnSetting;
    public BtnSpeedUp btnX2Speed;

    public Text txtMoney;
    public Text txtWave;
    public Text txtHealth;

    public PopupSettingInGame popUpSetting;
    public PopupLose popupLose;
    public PopupWin popupWin;
    protected override void Awake()
    {
        base.Awake();
        Hide();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void UpdatTxtMoney()
    {
        txtMoney.text = LevelManager.instance.curLevel.money.ToString();
    }
    public void UpdatTxtWave(int number, int maxWave)
    {
        txtWave.text = $"Wave {number}/{maxWave}";
    }
    public void UpdatTxtHealth(int number)
    {
        txtHealth.text = number.ToString();
    }
}
