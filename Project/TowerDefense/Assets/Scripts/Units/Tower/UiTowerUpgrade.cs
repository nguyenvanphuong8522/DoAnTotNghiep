using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiTowerUpgrade : BasePopup
{
    public static UiTowerUpgrade instance;
    public Transform range;
    public ButtonEffectLogic btnUpgrade, btnSell;
    [SerializeField] private TextMeshProUGUI txtPriceUpdate;
    [SerializeField] private TextMeshProUGUI txtPriceSell;
    [SerializeField] private Image imgBtnUpgrade;
    [SerializeField] private GameObject spriteUpgrade;

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
    public void UpdatePrice(int priceUpdate, int priceSell)
    {
        txtPriceUpdate.SetText(priceUpdate.ToString());
        txtPriceSell.SetText(priceSell.ToString());
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
    [Button]
    public void LockUpgrade()
    {
        btnUpgrade.enabled = false;
        spriteUpgrade.SetActive(false);
        txtPriceUpdate.text = "LOCK";
        txtPriceUpdate.color = Color.red;
    }
    [Button]
    public void Unlock()
    {
        btnUpgrade.enabled = true;
        imgBtnUpgrade.raycastTarget = true;
        txtPriceUpdate.color = Color.white;
    }
}
