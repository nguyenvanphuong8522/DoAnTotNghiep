using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InforTowerUi : Singleton<InforTowerUi>
{
    [SerializeField] private Text txtName;
    [SerializeField] private Text txtDescription;
    [SerializeField] private Button buy;
    [SerializeField] private GameObject locked; 
    [SerializeField] private GameObject purchased;
    
    public void UpdateInfor(string name, string desc)
    {
        SetNameAndDescript(name, desc);
        HideInforBottom();
    }
    private void SetNameAndDescript(string name, string desc)
    {
        txtName.text = name;
        txtDescription.text = desc;
    }
    private void HideInforBottom()
    {
        buy.gameObject.SetActive(false);
        locked.gameObject.SetActive(false);
        purchased.gameObject.SetActive(false);
    }


}
