using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBoard : Singleton<UpgradeBoard>
{
    public int idTower;
    [SerializeField] private List<Column> columns;
    public UpgradeBoardScriptable upgradeBoardData;
    public ListInforTowerSctipTable data;
    public ListInforTowerSctipTable dataBtnTower;
    public List<ListInforTowerSctipTable> listDataBtnUpgrade;

    private void Start()
    {
        SetData(0);
    }
    public void SetData(int id)
    {
        idTower = id;
        upgradeBoardData = PopupUpgrade.instance.upgradeBoardData[idTower];
        foreach(Column col in columns)
        {
            col.SetData();
        }
    }
    private void OnValidate()
    {
        columns.Clear();
        int index = 0;
        foreach(Transform t in transform)
        {
            Column col = t.GetComponent<Column>();
            if (col != null)
            {
                columns.Add(col);
                col.id = index++;
            }
        }
    }
}
