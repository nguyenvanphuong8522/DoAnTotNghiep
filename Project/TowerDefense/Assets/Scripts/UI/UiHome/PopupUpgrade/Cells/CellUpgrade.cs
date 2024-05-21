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
        btn.onClick.AddListener(UpdateBoard);
    }
    public void SetData(int indexColumn, int indexCell, UpgradeType type, bool unLocked, bool purchased)
    {
        upgradeType = type;
        imgIcon.sprite = PopupUpgrade.instance.tableTower.iconsCellData.optionSprites.array[(int)type];
        txtPrice.text = PopupUpgrade.instance.tableTower.pricesTower[indexColumn].list[indexCell].priceUpgrades[indexCell].ToString();
        this.indexCell = indexCell;
        this.indexColumn = indexColumn;
        this.unLocked = unLocked;
        this.purchased = purchased;
        locked.SetActive(!unLocked);
        gameObject.SetActive(true);
    }
    public override void UpdateBoard()
    {
        DescTowerSctiptable data = PopupUpgrade.instance.tableTower.descUpgradeData.list[(int)upgradeType];
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description, txtPrice.text);
        PopupUpgrade.instance.board.UpdateStateSell(purchased, unLocked);
    }
}
