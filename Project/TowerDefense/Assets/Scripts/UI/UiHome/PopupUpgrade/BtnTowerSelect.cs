using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTowerSelect : MonoBehaviour
{
    public int id;
    public Button btn;
    private UpgradeBoard upgradeBoard;
    public virtual void Start()
    {
        upgradeBoard = PopupUpgrade.instance.upgradeBoard;
        btn.onClick.AddListener(UpdateInfor); 
    }

    public virtual void UpdateInfor()
    {
        string nameTower = upgradeBoard.data.listDataTower[id].Name;
        string description = upgradeBoard.data.listDataTower[id].Description;
        InforTowerUi.instance.UpdateInfor(nameTower, description);
        upgradeBoard.SetData(id);
    }
}
