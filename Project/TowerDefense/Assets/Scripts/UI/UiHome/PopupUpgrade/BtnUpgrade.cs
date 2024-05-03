using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUpgrade : BtnTowerSelect
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Text txtPrice;

    public void SetData(Sprite sprite, int price)
    {
        imgIcon.sprite = sprite;
        txtPrice.text = $"{price} $";
    }
    public override void UpdateInfor()
    {

    }
}
