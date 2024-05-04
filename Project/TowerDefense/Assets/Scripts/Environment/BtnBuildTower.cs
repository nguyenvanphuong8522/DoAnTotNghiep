using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBuildTower : MonoBehaviour
{
    public int indexTower;
    public ButtonEffectLogic btn;
    public UiBuildTower uiBuilder;
    [SerializeField] private int price;
    private void Start()
    {
        btn.onClick.AddListener(BuildTower);
    }
    public void BuildTower()
    {
        if(LevelManager.instance.curLevel.money >= price)
        {
            LevelManager.instance.curLevel.money -= price;
            UiGameplay.instance.UpdatTxtMoney();
            ObjectPool.instance.Get(ObjectPool.instance.towers[indexTower].pools[0], uiBuilder.main.position);
            uiBuilder.Hide();
        }
        else
        {
            Debug.Log("not enough money");
        }
        
    }
    
}
