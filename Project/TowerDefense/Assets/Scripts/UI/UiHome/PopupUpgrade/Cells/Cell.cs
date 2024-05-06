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

    public void SetData(Sprite sprite, string price, CellType cellType, int indexColumn, int indexCell)
    {
        imgIcon.sprite = sprite;
        txtPrice.text = price;
        this.cellType = cellType;
        this.indexColumn = indexColumn;
        this.indexCell = indexCell;
        Active();
    }
    private void Active()
    {
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
        PopupUpgrade popupUpgrade = PopupUpgrade.instance;
        switch (cellType)
        {
            case CellType.TOWER:
                data = popupUpgrade.childrenInforTowerData[indexColumn].list[indexCell];
                break;
            case CellType.UPGRADE:
                data = popupUpgrade.inforUpgradeTypeData.list[indexCell];
                break;
            default:
                data = popupUpgrade.inforAbilitiesData[indexColumn].list[indexCell];
                break;
        }
        return data;
    }
}
