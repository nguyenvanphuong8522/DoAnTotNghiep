using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellUpgrade : CellTower
{
    public UpgradeType upgradeType;
    public override void Start()
    {
        btn.onClick.AddListener(UpdateBoard);
    }
    public void SetData(int indexColumn, int indexCell, UpgradeType type)
    {
        upgradeType = type;
        imgIcon.sprite = PopupUpgrade.instance.iconsCellData.optionSprites.array[(int)type];
        txtPrice.text = PopupUpgrade.instance.pricesTower[indexColumn].list[indexCell].priceUpgrades[indexCell].ToString();
        this.indexCell = indexCell;
        this.indexColumn = indexColumn;
        gameObject.SetActive(true);
    }
    public override void UpdateBoard()
    {
        DescTowerSctiptable data = PopupUpgrade.instance.descUpgradeData.list[(int)upgradeType];
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description);
    }
}
