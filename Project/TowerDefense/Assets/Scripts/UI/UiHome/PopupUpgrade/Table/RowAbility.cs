using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowAbility : MonoBehaviour
{
    public CellAbility[] cellAbilities;
    public RowAbilityScriptable data;

    public void SetData(RowAbilityScriptable data)
    {
        this.data = data;
    }
    public void SetRow()
    {
        for (int i = 0; i < cellAbilities.Length; i++)
        {
            int index = data.column[i].index;
            int level = data.column[i].level;
            bool unLocked = PopupUpgrade.instance.tableAbility.tableSave.rows[index].cells[level].unLocked;
            bool purchased = PopupUpgrade.instance.tableAbility.tableSave.rows[index].cells[level].purchased;
            cellAbilities[i].SetData(index, level, unLocked, purchased);
        }
        gameObject.SetActive(true);
    }
    private void HideCells()
    {
        foreach (CellAbility ability in cellAbilities)
        {
            ability.gameObject.SetActive(false);
        }
    }
}
