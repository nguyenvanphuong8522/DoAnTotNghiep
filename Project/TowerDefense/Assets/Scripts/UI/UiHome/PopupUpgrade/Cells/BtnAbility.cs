using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAbility : BtnTowerSelect
{
    public override void UpdateBoard()
    {
        PopupUpgrade popUpgrade = PopupUpgrade.instance;
        DescTowerSctiptable data = popUpgrade.tableAbility.descAbilityData.list[indexCell];
        popUpgrade.board.UpdateInfor(data.Name, data.Description);
        popUpgrade.tableAbility.gameObject.SetActive(true);
        popUpgrade.tableTower.gameObject.SetActive(false);
        popUpgrade.tableAbility.SetData();
        RectTransform myRect = GetComponent<RectTransform>();
        Vector3 newPos = new Vector3(0, myRect.anchoredPosition.y + 23, 0);
        popUpgrade.SetBoundMove(newPos);
    }

}
