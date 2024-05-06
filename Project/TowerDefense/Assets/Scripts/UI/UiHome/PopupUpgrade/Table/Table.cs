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
        UpdateTable(0);
    }
    public void UpdateTable(int id)
    {
        HideColumns();
        SetData(id);
    }
    private void SetData(int id)
    {
        idTable = id;
        tableData = PopupUpgrade.instance.tableData[idTable];
        int count = tableData.list.Count;

        for (int i = 0; i < count; i++)
        {
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
