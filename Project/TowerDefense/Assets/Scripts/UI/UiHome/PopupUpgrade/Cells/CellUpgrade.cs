using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CellUpgrade : CellTower
{
    public UpgradeType upgradeType;
    public override void Start()
    {
        popUpGrade = PopupUpgrade.instance;
        btn.onClick.AddListener(UpdateBoard);
    } 
    public void SetData(int indexColumn, int indexCell, UpgradeType type, bool unLocked, bool purchased)
    {
        popUpGrade = PopupUpgrade.instance;
        upgradeType = type;
        imgIcon.sprite = popUpGrade.tableTower.iconsCellData.optionSprites.array[(int)type];
        txtPrice.text = popUpGrade.tableTower.pricesTower[indexColumn].list[indexCell].priceUpgrades[indexCell].ToString();
        this.indexCell = indexCell;
        this.indexColumn = indexColumn;
        this.unLocked = unLocked;
        this.purchased = purchased;
        locked.SetActive(!unLocked);
        gameObject.SetActive(true);
    }
    public override void UpdateBoard()
    {
        popUpGrade = PopupUpgrade.instance;
        DescTowerSctiptable data = popUpGrade.tableTower.descUpgradeData.list[(int)upgradeType];
        popUpGrade.board.UpdateInfor(data.Name, data.Description, txtPrice.text);
        popUpGrade.board.UpdateStateSell(purchased, unLocked);
        popUpGrade.board.SetActionBuy(() =>
        {
            DataHangarSave.instance.PurchaseUpgrade(indexColumn, indexCell, upgradeType);
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
