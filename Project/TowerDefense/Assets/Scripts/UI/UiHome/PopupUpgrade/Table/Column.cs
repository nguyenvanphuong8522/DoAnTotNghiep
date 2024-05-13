using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Column : MonoBehaviour
{
    public int id;
    [SerializeField] private List<CellUpgrade> cells;
    [SerializeField] private CellTower cellColumn;
    [HideInInspector] public ColumnSctiptable colData;
    public GameObject cellsUpgrade;
    public void UpdateColumn()
    {
        HideCells();
        SetDataCells();
        Active();
    }
    private void Active()
    {
        gameObject.SetActive(true);
    }
    private void SetDataCells()
    {
        cellColumn.SetData(colData.indexTower, colData.level);
        if(colData.upgradeTypes.Length == 0)
        {
            cellsUpgrade.SetActive(false);
            return;
        }
        cellsUpgrade.SetActive(true);
        for (int i = 0; i < colData.upgradeTypes.Length; i++)
        {
            cells[i].SetData(colData.indexTower, colData.level, colData.upgradeTypes[i]);
        }
    }
    public void SetDataColumn(ColumnSctiptable colData)
    {
        this.colData = colData;
    }

    private void HideCells()
    {
        foreach (var cell in cells)
        {
            cell.gameObject.SetActive(false);
        }
    }
}
