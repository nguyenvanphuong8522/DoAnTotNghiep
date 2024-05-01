using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBuildTower : MonoBehaviour
{
    public int indexTower;
    public ButtonEffectLogic btn;
    public UiBuildTower uiBuilder;
    private void Start()
    {
        btn.onClick.AddListener(BuildTower);
    }
    public void BuildTower()
    {
        ObjectPool.instance.Get(ObjectPool.instance.towers[indexTower].pools[0], uiBuilder.main.position);
        uiBuilder.Hide();
    }
    
}
