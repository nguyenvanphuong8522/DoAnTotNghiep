using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellAbility : BtnTowerSelect
{
    [SerializeField] protected Image imgIcon;
    [SerializeField] protected Text txtPrice;
    public int indexColumn;
    [SerializeField] protected GameObject locked;
    protected bool purchased;
    protected bool unLocked;
    public void SetData(int indexRow, int indexCell, bool unLocked, bool purchased)
    {
        imgIcon.sprite = PopupUpgrade.instance.tableAbility.icons.abilitySprites[indexRow].array[indexCell];
        txtPrice.text = PopupUpgrade.instance.tableAbility.priceAbilities.rows[indexRow].cells[indexCell].ToString();
        this.indexCell = indexCell;
        indexColumn = indexRow;
        locked.SetActive(!unLocked);
        this.purchased = purchased;
        this.unLocked = unLocked;
        gameObject.SetActive(true);
    }
    public override void UpdateBoard()
    {
        PopupUpgrade popUpGrade = PopupUpgrade.instance;
        DescTowerSctiptable data = PopupUpgrade.instance.tableAbility.descAbilitiesData[indexColumn].list[indexCell];
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description, txtPrice.text);
        popUpGrade.board.UpdateStateSell(purchased, unLocked);
        popUpGrade.board.SetActionBuy(() =>
        {
            popUpGrade.tableAbility.Purchase(indexColumn, indexCell);
            popUpGrade.tableAbility.SetData();
            popUpGrade.board.UpdateStateSell(purchased, unLocked);
        });
        if (DataPersist.Money < popUpGrade.tableAbility.priceAbilities.rows[indexColumn].cells[indexCell])
        {
            popUpGrade.board.BlurBtnBuy();
            return;
        }
        popUpGrade.board.ShowBuy();
    }
}
