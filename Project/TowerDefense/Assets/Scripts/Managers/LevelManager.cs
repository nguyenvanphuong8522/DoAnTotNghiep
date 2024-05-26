using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public ListLevelScriptable listLevelData;
    public Level curLevel;
    public int indexLevel;
    public StarLevelSave starsLevel;

    private void Start()
    {
        if(PlayerPrefs.HasKey("LEVELSTAR"))
        {
            starsLevel = JsonConvert.DeserializeObject<StarLevelSave>(DataPersist.JsonStarLevel);
        }
        else
        {
            starsLevel = new StarLevelSave();
            Save();
        }
    }
    public void SetStarLeve(int amountStar)
    {
        starsLevel.levelStars[indexLevel] = amountStar;
        Save();
    }
    private void Save()
    {
        DataPersist.JsonStarLevel = starsLevel.ToString();
    }

    [Button]
    public void Test()
    {
        InitLevel(1);
    }
    public void InitLevel(int index)
    {
        indexLevel = index;
        CameraController.instance.transform.position = listLevelData.levels[indexLevel].posCamera;
        curLevel.InitLevel(index, listLevelData);
        if (index == 0 && DataPersist.Tutorialed == 0)
        {
            GameTutorial.instance.StartTutorial();
        }
        
        
    }
    [Button]
    public void RestartLevel()
    {
        RemoveOldLevel();
        InitLevel(indexLevel);
        
    }

    public void RemoveOldLevel()
    {
        Loading.instance.Show();
        GameEvent.CallReturnLevel();
        curLevel.Stop();
        ObjectPool.instance.ReturnAllPool();
    }
}
