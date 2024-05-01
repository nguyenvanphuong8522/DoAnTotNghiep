using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiTowerUpgrade : BasePopup
{
    public static UiTowerUpgrade instance;
    public Transform range;
    public ButtonEffectLogic btnUpgrade, btnSell;

    protected override void Awake()
    {
        instance = this;
        base.Awake();
        Hide();
    }
    public void SetPos(Vector3 pos)
    {
        main.position = pos;
    }
    public void UpdateRange(Vector3 range)
    {
        this.range.localScale = range;
    }
    public void UpDateUi(Vector3 pos, Vector3 range)
    {
        SetPos(pos);
        UpdateRange(range);
    }

    public void RemoveListener()
    {
        btnUpgrade.onClick.RemoveAllListeners();
        btnSell.onClick.RemoveAllListeners();
    }
    public void AddListener(UnityAction action1, UnityAction action2)
    {
        RemoveListener();
        btnUpgrade.onClick.AddListener(action1);
        btnSell.onClick.AddListener(action2);
    }
}
