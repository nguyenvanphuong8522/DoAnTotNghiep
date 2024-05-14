using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class DesignLevel : Singleton<DesignLevel>
{
    public ListLevelScriptable data;
    public int level;
    public int typeWeather;
    public List<ObstacleScriptable> obstacles;
    public Transform tileObstacles;
    public Transform tileRoad;
    public ListWaveScriptable listWave;

    protected override void Awake()
    {
        base.Awake();
    }


#if UNITY_EDITOR
    [Button]
    public void Save()
    {
        data.levels[level].listObstacle = obstacles;
        data.levels[level].waves = listWave;
        EditorUtility.SetDirty(data);
        EditorUtility.SetDirty(listWave);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
#endif

    [Button]
    public void ChangeObstacles()
    {
        obstacles.Clear();
        foreach (Transform element in tileObstacles)
        {
            ObstacleScriptable newData = new ObstacleScriptable();
            newData.pos = element.position;
            newData.type = typeWeather;
            int intName = Convert.ToInt32(element.name);
            newData.name = (NameObstacle)intName;
            obstacles.Add(newData);
        }
    }
    [Button]
    public void ChangeRoad()
    {
        listWave.paths[0] = new Path();
        listWave.paths[0].path = new Vector2[tileRoad.childCount];
        for (int i = 0; i < tileRoad.childCount; i++)
        {
            listWave.paths[0].path[i] = (Vector2)tileRoad.GetChild(i).position;
        }
    }

}
