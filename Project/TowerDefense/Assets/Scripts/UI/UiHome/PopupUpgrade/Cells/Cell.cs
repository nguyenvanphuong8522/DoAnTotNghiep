using UnityEngine;
using UnityEngine.UI;

public class Cell : BtnTowerSelect
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Text txtPrice;
    public UpgradeType cellType;
    public int indexColumn;
    public GameObject locked;
    public bool purchased;

    public override void Start()
    {
        btn.onClick.AddListener(UpdateBoard);
    }

    public void SetData(Sprite sprite, string price, UpgradeType cellType, int indexColumn, int indexCell)
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
    public override void UpdateBoard() 
    {

    }

}
