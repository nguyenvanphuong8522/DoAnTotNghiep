using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnBuildTower : MonoBehaviour
{
    public int indexTower;
    public ButtonEffectLogic btn;
    public UiBuildTower uiBuilder;
    [SerializeField] private int price;
    [SerializeField] private GameObject lockObj;
    [SerializeField] private GameObject icon;
    [SerializeField] private TextMeshProUGUI txtPrice;
    [SerializeField] private GameObject txtPriceObj;
    [SerializeField] private Image imgBg;
    private void Start()
    {
        btn.onClick.AddListener(BuildTower);
        UpdatePrice();
    }
    public void BuildTower()
    {
        if(LevelManager.instance.curLevel.money >= price)
        {
            LevelManager.instance.curLevel.money -= price;
            UiGameplay.instance.UpdatTxtMoney();
            ObjectPool.instance.Get(ObjectPool.instance.towers[indexTower].pools[0], uiBuilder.main.position);
            uiBuilder.Hide();
        }
        else
        {
            Debug.Log("not enough money");
        }
    }
    [Button]
    public void Lock()
    {
        lockObj.SetActive(true);
        icon.SetActive(false);
        txtPriceObj.SetActive(false);
        imgBg.raycastTarget = false;
    }
    [Button]
    public void Unlock()
    {
        icon.SetActive(true);
        lockObj.SetActive(false);
        txtPriceObj.SetActive(true);
        imgBg.raycastTarget = true;
    }

    public void UpdatePrice()
    {
        txtPrice.text = price.ToString();
    }
    
}
