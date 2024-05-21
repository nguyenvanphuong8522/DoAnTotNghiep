using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Board : Singleton<Board>
{
    [SerializeField] private Text txtName;
    [SerializeField] private Text txtDescription;
    [SerializeField] private Text price;
    [SerializeField] private Button buy;
    [SerializeField] private GameObject locked; 
    [SerializeField] private GameObject purchased;
    private void Start()
    {
        DescTowerSctiptable data = PopupUpgrade.instance.tableTower.descStrategyData.list[0];

        UpdateInfor(data.Name, data.Description);
    }
    public void UpdateInfor(string name, string desc)
    {
        SetNameAndDescript(name, desc);
        HideInforBottom();
    }
    public void UpdateStateSell(bool purchased, bool unLocked)
    {
        locked.SetActive(!unLocked);
        if(!unLocked)
        {
            buy.gameObject.SetActive(false);
            this.purchased.SetActive(false);
            return;
        }
        buy.gameObject.SetActive(!purchased);
        this.purchased.gameObject.SetActive(purchased);
    }
    public void UpdateInfor(string name, string desc, string price)
    {
        SetNameAndDescript(name, desc);
        this.price.text = "Price: $" + price;
        HideInforBottom();
        this.price.gameObject.SetActive(true);
    }

    public void UpdateInfor(string name, string desc, bool purchased)
    {
        SetNameAndDescript(name, desc);
        HideInforBottom();
    }
    private void SetNameAndDescript(string name, string desc)
    {
        txtName.text = name;
        txtDescription.text = desc;
    }
    private void HideInforBottom()
    {
        price.gameObject.SetActive(false);
        buy.gameObject.SetActive(false);
        locked.gameObject.SetActive(false);
        purchased.gameObject.SetActive(false);
    }
}
