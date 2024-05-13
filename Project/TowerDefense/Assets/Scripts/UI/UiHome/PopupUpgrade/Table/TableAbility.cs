using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAbility : MonoBehaviour
{
    [SerializeField] private TableAbilityScriptable data;
    public List<TablePriceAbility> priceAbilities;
    public RowAbility[] columnAbilities;
    public List<DescTowersScriptable> descAbilitiesData;
    public DescTowersScriptable descAbilityData;
    public AbilitySprites icons;

    public void SetData()
    {
        HideRows();
        for(int i = 0; i < columnAbilities.Length; i++)
        {
            columnAbilities[i].SetData(data.table[i]);
            columnAbilities[i].SetRow();
        }
    }
    private void HideRows()
    {
        foreach (RowAbility ability in columnAbilities)
        {
            ability.gameObject.SetActive(false);
        }
    }
}
