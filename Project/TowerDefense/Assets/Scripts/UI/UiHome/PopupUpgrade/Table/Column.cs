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
    public void UpdateColumn()
    {
        HideCells();
        SetData();
        Active();
    }
    private void Active()
    {
        gameObject.SetActive(true);
    }
    private void SetData()
    {
        cellColumn.SetData(colData.indexTower, colData.level);
        for (int i = 0; i < colData.upgradeTypes.Length; i++)
        {
            cells[i].SetData(colData.indexTower, colData.level, colData.upgradeTypes[i]);
        }
    }

    private void HideCells()
    {
        foreach (var cell in cells)
        {
            cell.gameObject.SetActive(false);
        }
    }
}
