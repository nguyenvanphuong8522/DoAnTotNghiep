using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public int id;
    [SerializeField] private List<Cell> cells;
    private CellScriptable[] cellsData;
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
        cellsData = Table.instance.tableData.list[id].column;
        int length = cellsData.Length;

        for (int i = 0; i < length; i++)
        {
            CellScriptable data = cellsData[i];

            string price = data.price.ToString();
            Sprite sprite = ConvertTypeToSprite.CellTypeToSprite(data.type, data.indexColumn, data.indexCell);
            cells[i].SetData(sprite, price, data.type, data.indexColumn, data.indexCell);
        }
    }

    private void HideCells()
    {
        foreach(var cell in cells)
        {
            cell.gameObject.SetActive(false);
        }
    }

    #region Validate
    private void OnValidate()
    {
        cells.Clear();
        int index = 0;
        foreach (Transform child in transform)
        {
            Cell btnOption = child.GetComponent<Cell>();
            if (btnOption == null) return;

            cells.Add(btnOption);
            btnOption.indexCell = index++;
        }
    }
    #endregion
}
