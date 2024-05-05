using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public int id;
    [SerializeField] private List<Cell> cells;
    private ColumnSctiptable columnData;
    public void SetData()
    {
        HideCells();
        columnData = Table.instance.tableData.listColumn[id];
        int length = columnData.column.Length;
        for (int i = 0; i < length; i++)
        {
            CellScriptable cellData = columnData.column[i];
            int price = cellData.price;
            Sprite sprite = CellTypeToSprite(cellData.type, cellData.index);
            cells[i].SetData(sprite, price, cellData.type, cellData.index);
            cells[i].indexColumn = id;
        }
        gameObject.SetActive(true);
    }
    private Sprite CellTypeToSprite(CellType type, int index = 0)
    {
        Sprite newSprite;
        IconsCellScriptable data = PopupUpgrade.instance.iconsCellData;
        int _index = Table.instance.idTable;
        switch (type)
        {
            case CellType.TOWER:
                newSprite = data.towerSprites[_index].array[id];
                break;
            case CellType.UPGRADE:
                newSprite = data.optionSprites[index];
                break;
            default:
                newSprite = data.abilitySprites[id].array[index];
                break;
        }
        return newSprite;
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
            btnOption.id = index++;
        }
    }
    #endregion
}
