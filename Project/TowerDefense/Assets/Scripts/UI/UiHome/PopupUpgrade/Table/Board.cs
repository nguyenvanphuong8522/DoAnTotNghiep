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
        DescTowerSctiptable data = PopupUpgrade.instance.descStrategyData.list[0];

        UpdateInfor(data.Name, data.Description);
    }
    public void UpdateInfor(string name, string desc)
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
