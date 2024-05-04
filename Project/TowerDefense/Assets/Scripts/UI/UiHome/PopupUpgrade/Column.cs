using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public int id;
    [SerializeField] private List<BtnUpgrade> listBtnUpgrade;
    private ColumnSctiptable columnData;
    public void SetData()
    {
        columnData = UpgradeBoard.instance.upgradeBoardData.listColumn[id];
        int length = columnData.column.Length;
        for (int i = 0; i < length; i++)
        {
            int price = columnData.column[i].price;
            Sprite sprite = OptionTypeToSprite(columnData.column[i].type, columnData.column[i].index);
            listBtnUpgrade[i].SetData(sprite, price);
        }
    }
    private Sprite OptionTypeToSprite(OptionTye type, int index = 0)
    {
        Sprite newSprite;
        ListIconBtnUpgradeScriptable data = PopupUpgrade.instance.listIconBtnUpgrade;
        int _index = UpgradeBoard.instance.idTower;
        switch (type)
        {
            case OptionTye.TOWER:
                newSprite = data.towerSprites[_index].array[id];
                break;
            case OptionTye.UPGRADE:
                newSprite = data.optionSprites[index];
                break;
            default:
                newSprite = data.abilitySprites[index].array[id];
                break;
        }
        return newSprite;
    }


    private void OnValidate()
    {
        listBtnUpgrade.Clear();
        int index = 0;
        foreach (Transform child in transform)
        {
            BtnUpgrade btnOption = child.GetComponent<BtnUpgrade>();
            if (btnOption == null) return;

            listBtnUpgrade.Add(btnOption);
            btnOption.id = index++;
        }
    }
}
