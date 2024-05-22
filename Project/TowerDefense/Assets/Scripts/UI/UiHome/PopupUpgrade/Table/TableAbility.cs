using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAbility : MonoBehaviour
{
    [SerializeField] private TableAbilityScriptable data;
    public TablePriceAbility priceAbilities;
    public RowAbility[] columnAbilities;
    public List<DescTowersScriptable> descAbilitiesData;
    public DescTowersScriptable descAbilityData;
    public AbilitySprites icons;



    public TableAbilitySave tableSave;
    private void Awake()
    {
        CheckInitData();
    }
    public void SetData()
    {
        HideRows();
        for (int i = 0; i < columnAbilities.Length; i++)
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




    public void CheckInitData()
    {
        if (!PlayerPrefs.HasKey("ABILITY"))
        {
            InitTableSave();
            Save();
            Debug.Log(DataPersist.JsonAbility);
            return;
        }
        Debug.Log("has key");
        tableSave = GetOldData();
    }
    private void InitValue()
    {
        tableSave.rows[0].cells[0].Unlock();
        tableSave.rows[1].cells[0].Unlock();
    }
    private void InitTableSave()
    {
        tableSave = new TableAbilitySave(2);
        InitValue();
    }
    private TableAbilitySave GetOldData()
    {
        return JsonConvert.DeserializeObject<TableAbilitySave>(DataPersist.JsonAbility);
    }
    private void Save()
    {
        DataPersist.JsonAbility = tableSave.ToString();
    }
    public bool IsUnLocked(int indexRow, int indexCell)
    {
        return tableSave.rows[indexRow].cells[indexCell].unLocked;
    }
    public bool IsPurchased(int indexRow, int indexCell)
    {
        return tableSave.rows[indexRow].cells[indexCell].purchased;
    }

    public void Purchase(int indexRow, int indexCell)
    {
        tableSave.rows[indexRow].cells[indexCell].Purchase();
        DataPersist.Money -= priceAbilities.rows[indexRow].cells[indexCell];
        PopupUpgrade.instance.UpdateTxtMoney();
        if (indexCell < 1)
        {
            Unlock(indexRow, indexCell + 1);
        }
        Save();
    }

    public void Unlock(int indexRow, int indexCell)
    {
        tableSave.rows[indexRow].cells[indexCell].Unlock();
        Save();
    }

}
