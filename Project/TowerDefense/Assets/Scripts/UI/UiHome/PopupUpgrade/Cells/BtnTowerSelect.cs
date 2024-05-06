using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTowerSelect : MonoBehaviour
{
    public int indexCell;
    public Button btn;
    public virtual void Start()
    {
        btn.onClick.AddListener(UpdateInfor); 
    }

    public virtual void UpdateInfor()
    {
        InforTowerSctiptable data = PopupUpgrade.instance.inforTowersData.list[indexCell];

        Board.instance.UpdateInfor(data.Name, data.Description);
        PopupUpgrade.instance.table.UpdateTable(indexCell);
    }
}
