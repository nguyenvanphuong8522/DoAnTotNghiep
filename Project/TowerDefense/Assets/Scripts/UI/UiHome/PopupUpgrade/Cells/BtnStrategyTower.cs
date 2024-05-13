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
        popUpgrade.tableTower.UpdateTable(indexCell);
        popUpgrade.tableAbility.gameObject.SetActive(false);
        popUpgrade.tableTower.gameObject.SetActive(true);
    }
    
}
