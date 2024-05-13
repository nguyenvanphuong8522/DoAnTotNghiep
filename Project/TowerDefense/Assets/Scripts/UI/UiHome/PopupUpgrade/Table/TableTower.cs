using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTower : Singleton<TableTower>
{
    public int idTable;
    [SerializeField] private List<Column> columns;

    public List<TableScriptable> towerTableData;
    [Header("Price")]
    public List<Prices> pricesTower;
    [Header("Icons")]
    public IconsCellScriptable iconsCellData;
    public List<DescTowersScriptable> descTowersData;
    public DescTowersScriptable descStrategyData;
    public DescTowersScriptable descUpgradeData;

    public void UpdateTable(int id)
    {
        HideColumns();
        SetData(id);
    }
    private void SetData(int id)
    {
        idTable = id;
        int count = towerTableData[id].columns.Count;

        for (int i = 0; i < count; i++)
        {
            columns[i].SetDataColumn(towerTableData[id].columns[i]);
            columns[i].UpdateColumn();
        }
    }
    private void HideColumns()
    {
        foreach (Column col in columns)
        {
            col.gameObject.SetActive(false);
        }
    }
}
