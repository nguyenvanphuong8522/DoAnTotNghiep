using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellTower : BtnTowerSelect
{
    [SerializeField] protected Image imgIcon;
    [SerializeField] protected Text txtPrice;
    public int indexColumn;
    [SerializeField] protected GameObject locked;
    protected bool purchased;
    protected bool unLocked;
    protected PopupUpgrade popUpGrade;

    public override void Start()
    {
        popUpGrade = PopupUpgrade.instance;
        btn.onClick.AddListener(UpdateBoard);
    }
    public virtual void SetData(int indexColumn, int indexCell, bool unLocked, bool purchased)
    {
        popUpGrade = PopupUpgrade.instance;
        imgIcon.sprite = PopupUpgrade.instance.tableTower.iconsCellData.towerSprites[indexColumn].array[indexCell];
        imgIcon.SetNativeSize();
        imgIcon.transform.localScale = Vector3.one * 0.65f;

        txtPrice.text = popUpGrade.tableTower.pricesTower[indexColumn].list[indexCell].priceUnlock.ToString();
        this.indexCell = indexCell;
        this.indexColumn = indexColumn;
        locked.SetActive(!unLocked);
        this.purchased = purchased;
        this.unLocked = unLocked;
        gameObject.SetActive(true);
    }
    public override void UpdateBoard()
    {

        DescTowerSctiptable data = popUpGrade.tableTower.descTowersData[indexColumn].list[indexCell];
        popUpGrade.board.UpdateInfor(data.Name, data.Description, txtPrice.text);
        popUpGrade.board.UpdateStateSell(purchased, unLocked);
        popUpGrade.board.SetActionBuy(() =>
        {
            DataHangarSave.instance.Purchase(indexColumn, indexCell);
            popUpGrade.tableTower.Refresh();
            popUpGrade.board.UpdateStateSell(purchased, unLocked);
        });
        if (DataPersist.Money < popUpGrade.tableTower.pricesTower[indexColumn].list[indexCell].priceUnlock)
        {
            popUpGrade.board.BlurBtnBuy();
            return;
        }
        popUpGrade.board.ShowBuy();
    }
}
