using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public EnemiesDataScriptable enemiesData;
    public DataTowerUpgrade towersData;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            DataPersist.Tutorialed = -3;
        }
        else if(Input.GetKeyDown(KeyCode.Y)) 
        {
            DataPersist.Tutorialed = 3;
        }
    }
}
