using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : BtnTowerSelect
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Text txtPrice;
    public CellType cellType;
    public int indexColumn;

    public override void Start()
    {
        btn.onClick.AddListener(UpdateInfor);
    }
    public void SetData(Sprite sprite, int price, CellType cellType, int id)
    {
        imgIcon.sprite = sprite;
        txtPrice.text = $"{price} $";
        this.cellType = cellType;
        this.id = id;
        gameObject.SetActive(true);
    }
    public override void UpdateInfor() 
    {
        InforTowerSctiptable data = GetData(cellType);
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description);
    }

    private InforTowerSctiptable GetData(CellType cellType)
    {
        InforTowerSctiptable data = new InforTowerSctiptable();
        switch (cellType)
        {
            case CellType.TOWER:
                data = PopupUpgrade.instance.childrenInforTowerData[PopupUpgrade.instance.table.idTable].list[id];
                break;
            case CellType.UPGRADE:
                data = PopupUpgrade.instance.inforUpgradeTypeData.list[id];
                break;
            default:
                data = PopupUpgrade.instance.inforAbilitiesData[indexColumn].list[id];
                break;
        }
        return data;
    }
}
