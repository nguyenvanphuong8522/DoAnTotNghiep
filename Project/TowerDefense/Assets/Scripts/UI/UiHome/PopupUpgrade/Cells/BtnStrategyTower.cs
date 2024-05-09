using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnStrategyTower : BtnTowerSelect
{
    public override void UpdateBoard()
    {
        DescTowerSctiptable data = PopupUpgrade.instance.descStrategyData.list[indexCell];
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description);
        PopupUpgrade.instance.table.UpdateTable(indexCell, PopupUpgrade.instance.towerTableData[indexCell]);
    }
    
}
