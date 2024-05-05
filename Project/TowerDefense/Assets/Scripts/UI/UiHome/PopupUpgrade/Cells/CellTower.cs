using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellTower : BtnTowerSelect
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Text txtPrice;
    public int indexColumn;

    public override void Start()
    {
        btn.onClick.AddListener(UpdateInfor);
    }
    public void SetData(int price, int indexColumn, int id)
    {
        imgIcon.sprite = PopupUpgrade.instance.iconsCellData.towerSprites[indexColumn].array[id];
        txtPrice.text = $"{price} $";
        this.id = id;
        this.indexColumn = indexColumn;
        gameObject.SetActive(true);
    }
    public override void UpdateInfor()
    {
        InforTowerSctiptable data = PopupUpgrade.instance.childrenInforTowerData[indexColumn].list[id];
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description);
    }
}
