using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Singleton<Table>
{
    public int idTable;
    [SerializeField] private List<Column> columns;

    [HideInInspector]public TableScriptable tableData;

    public void UpdateTable(int id, TableScriptable tableDat)
    {
        HideColumns();
        SetData(id, tableDat);
    }
    private void SetData(int id, TableScriptable tableData)
    {
        idTable = id;
        this.tableData = tableData;
        int count = tableData.columns.Count;

        for (int i = 0; i < count; i++)
        {
            columns[i].colData = tableData.columns[i];
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
