using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InforTowerUi : Singleton<InforTowerUi>
{
    [SerializeField] private Text txtName;
    [SerializeField] private Text txtDescription;
    [SerializeField] private Button buy;
    [SerializeField] private ListInforTowerSctipTable data;
    private void Start()
    {
        UpdateInfor(0);
    }
    public void UpdateInfor(int id)
    {
        txtName.text = data.listDataTower[id].Name;
        txtDescription.text = data.listDataTower[id].Description;
    }
}
