using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InforTowerUi : MonoBehaviour
{
    [SerializeField] private Text txtName;
    [SerializeField] private Text txtDescription;
    [SerializeField] private Button buy;
    [SerializeField] private ListInforTowerSctipTable data;
    private void Start()
    {
        UpdateInfor(0);
    }
    public void UpdateInfor(int index)
    {
        txtName.text = data.listDataTower[index].Name;
        txtDescription.text = data.listDataTower[index].Description;
    }
}
