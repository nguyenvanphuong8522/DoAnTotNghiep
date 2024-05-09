using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAbility : BtnTowerSelect
{
    public override void UpdateBoard()
    {
        DescTowerSctiptable data = PopupUpgrade.instance.descAbilityData.list[indexCell];
        PopupUpgrade.instance.board.UpdateInfor(data.Name, data.Description);
        PopupUpgrade.instance.table.UpdateTable(indexCell, PopupUpgrade.instance.abilityTableData[0]);
    }

}
