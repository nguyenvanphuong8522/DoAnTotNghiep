using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Column : MonoBehaviour
{
    public int id;
    [SerializeField] private List<CellUpgrade> cells;
    [SerializeField] private CellTower cellColumn;
    [HideInInspector] public ColumnSctiptable colData;
    public GameObject cellsUpgrade;
    [SerializeField] private LineEffect lineEffect;
    public RectTransform rect0;
    private Coroutine delayEffect;
    public void UpdateColumn()
    {
        HideCells();
        SetDataCells();
        Active();
    }
    private void Active()
    {
        gameObject.SetActive(true);
        if(delayEffect != null )
        {
        StopCoroutine(delayEffect);

        }
        delayEffect = StartCoroutine(UpdateEffectLine());
    }
    [Button]
    private void SetDataCells()
    {
        bool unLocked = DataHangarSave.instance.IsUnLocked(colData.indexTower, colData.level);
        bool purchased = DataHangarSave.instance.IsPurchased(colData.indexTower, colData.level);
        cellColumn.SetData(colData.indexTower, colData.level, unLocked, purchased);
        int length = colData.upgradeTypes.Length;
        if (length == 0)
        {
            cellsUpgrade.SetActive(false);
            return;
        }
        cellsUpgrade.SetActive(true);
        for (int i = 0; i < length; i++)
        {
            bool _unLocked = DataHangarSave.instance.GetUpgradeSave(colData.indexTower, colData.level)[i].unLocked;
            bool _purchased = DataHangarSave.instance.GetUpgradeSave(colData.indexTower, colData.level)[i].purchased;
            cells[i].SetData(colData.indexTower, colData.level, colData.upgradeTypes[i], _unLocked, _purchased);
        }
    }
    public void SetDataColumn(ColumnSctiptable colData)
    {
        this.colData = colData;
    }

    private void HideCells()
    {
        foreach (var cell in cells)
        {
            cell.gameObject.SetActive(false);
        }
    }

    public IEnumerator UpdateEffectLine()
    {
        yield return new WaitForEndOfFrame();
        lineEffect.ClearPoints();
        lineEffect.AddPoint(rect0.position);
        for (int i = 0; i < colData.upgradeTypes.Length; i++)
        {
            lineEffect.AddPoint(cells[i].GetComponent<RectTransform>().position);
        }
    }
    private void OnDisable()
    {
        lineEffect.ClearPoints();
    }
}
