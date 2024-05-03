using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTowerSelect : MonoBehaviour
{
    public int id;
    [SerializeField] private Button btn;
    public virtual void Start()
    {
        btn.onClick.AddListener(UpdateInfor); 
    }

    public virtual void UpdateInfor()
    {
        InforTowerUi.instance.UpdateInfor(id);
        UpgradeBoard.instance.SetData(id);
    }
}
