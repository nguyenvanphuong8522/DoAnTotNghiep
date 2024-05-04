using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUpgrade : BtnTowerSelect
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Text txtPrice;
    private int price;
    public int indexColumn;

    public override void Start()
    {
        //btn.onClick.AddListener(UpdateInfor)
    }
    public void SetData(Sprite sprite, int price)
    {
        imgIcon.sprite = sprite;
        txtPrice.text = $"{price} $";
        this.price = price;
    }
    public override void UpdateInfor()
    {
        //UpgradeBoard.instance.da
    }
}
