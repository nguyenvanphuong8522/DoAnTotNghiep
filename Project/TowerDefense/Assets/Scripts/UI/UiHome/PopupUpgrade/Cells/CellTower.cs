using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellTower : BtnTowerSelect
{
    [SerializeField] protected Image imgIcon;
    [SerializeField] protected Text txtPrice;
    public int indexColumn;

    public override void Start()
    {
        btn.onClick.AddListener(UpdateBoard);
    }
    public virtual void SetData(int indexColumn, int indexCell)
    {
        imgIcon.sprite = PopupUpgrade.instance.tableTower.iconsCellData.towerSprites[indexColumn].array[indexCell];
        imgIcon.SetNativeSize();
        imgIcon.transform.localScale = Vector3.one * 0.65f;

        txtPrice.text = PopupUpgrade.instance.tableTower.pricesTower[indexColumn].list[indexCell].priceUnlock.ToString();
        this.indexCell = indexCell;
        this.indexColumn = indexColumn;
        gameObject.SetActive(true);
    }
    public override void UpdateBoard()
    {
        DescTowerSctiptable data = PopupUpgrade.instance.tableTower.descTowersData[indexColumn].list[indexCell];
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description);
    }
}
