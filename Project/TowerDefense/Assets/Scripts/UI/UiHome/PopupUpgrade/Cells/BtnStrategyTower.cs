using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnStrategyTower : BtnTowerSelect
{
    public override void UpdateBoard()
    {
        PopupUpgrade popUpgrade = PopupUpgrade.instance;
        DescTowerSctiptable data = popUpgrade.tableTower.descStrategyData.list[indexCell];
        popUpgrade.board.UpdateInfor(data.Name, data.Description);
        popUpgrade.tableAbility.gameObject.SetActive(false);
        popUpgrade.tableTower.gameObject.SetActive(true);
        popUpgrade.tableTower.UpdateTable(indexCell);
        RectTransform myRect = GetComponent<RectTransform>();
        Vector3 newPos = new Vector3(0, myRect.anchoredPosition.y + 23, 0);
        popUpgrade.SetBoundMove(newPos);
    }
}
