using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiTowerUpgrade : Singleton<UiTowerUpgrade>
{
    public bool isShowing = false;
    public Transform indicator;
    public Transform canvas;
    public Transform range;

    public Button btnUpgrade, btnSell;

    public void SetShowHide()
    {
        isShowing = !isShowing;
        SetActiveUiBuilder(isShowing);
    }
    public void SetActiveUiBuilder(bool value)
    {
        indicator.gameObject.SetActive(value);
        canvas.gameObject.SetActive(value);
        isShowing = value;
    }
    public void SetPos(Vector3 pos)
    {
        indicator.position = canvas.position = pos;
    }
    public void UpdateRange(Vector3 range)
    {
        this.range.localScale = range;
    }
    public void UpDateUi(Vector3 pos, Vector3 range)
    {
        SetPos(pos);
        UpdateRange(range);
        SetShowHide();
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
