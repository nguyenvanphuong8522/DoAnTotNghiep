using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellAbility : BtnTowerSelect
{
    [SerializeField] protected Image imgIcon;
    [SerializeField] protected Text txtPrice;
    public int indexColumn;
    public virtual void SetData(int indexRow, int indexCell)
    {
        imgIcon.sprite = PopupUpgrade.instance.tableAbility.icons.abilitySprites[indexRow].array[indexCell];
        txtPrice.text = PopupUpgrade.instance.tableAbility.priceAbilities[0].rows[indexRow].cells[indexCell].ToString();
        this.indexCell = indexCell;
        indexColumn = indexRow;
        gameObject.SetActive(true);
    }
    public override void UpdateBoard()
    {
        DescTowerSctiptable data = PopupUpgrade.instance.tableTower.descTowersData[indexColumn].list[indexCell];
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description);
    }
}
