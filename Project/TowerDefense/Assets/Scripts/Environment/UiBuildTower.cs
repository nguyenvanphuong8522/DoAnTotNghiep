using System;
using System.Collections.Generic;
using UnityEngine;

public class UiBuildTower : BasePopup
{
    [SerializeField] private List<BtnBuildTower> btnBuildTowerList;
    protected override void Awake()
    {
        base.Awake();
        Hide();
    }
    public void SetPos(Vector3 pos)
    {
        main.position = pos;
    }

    public void Lock(int[] arrLock)
    {
        for(int i = 0; i < arrLock.Length; i++)
        {
            if (arrLock[i] == 0)
            {
                btnBuildTowerList[i].Lock();
            }
            else
            {
                btnBuildTowerList[i].Unlock();
            }
        }
        DataTablesSave tbSave = DataHangarSave.instance.tablesSave;
        for (int i = 0;i <tbSave.dataTablesSave.Count; i++)
        {
            if (!tbSave.dataTablesSave[i].columnSaves[0].purchased)
            {
                btnBuildTowerList[i].Lock();
            }
        }
    }
}
