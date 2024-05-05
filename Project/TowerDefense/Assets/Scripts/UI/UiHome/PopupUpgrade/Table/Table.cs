using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Singleton<Table>
{
    public int idTable;
    [SerializeField] private List<Column> columns;

    [HideInInspector]public TableScriptable tableData;

    private void Start()
    {
        SetData(0);
    }
    public void SetData(int id)
    {
        HideColumns();
        idTable = id;
        tableData = PopupUpgrade.instance.tableData[idTable];
        for (int i = 0; i < tableData.listColumn.Count; i++)
        {
            columns[i].SetData();
        }
    }
    private void HideColumns()
    {
        foreach (Column column in columns)
        {
            column.gameObject.SetActive(false);
        }
    }
    #region Validate
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
    #endregion
}
