using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class DesignLevel : Singleton<DesignLevel>
{
    public ListLevelScriptable data;
    public int level;
    public List<ObstacleScriptable> obstacles;
    public Transform tileObstacles;
    public Transform tileRoad;
    public ListWaveScriptable listWave;

    protected override void Awake()
    {
        base.Awake();
        obstacles = data.levels[level].listObstacle;
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
        foreach (Transform element in tileObstacles)
        {
            string OBname = element.name;
            NameObstacle intName = (NameObstacle)Convert.ToInt32(element.name.Substring(0, 1));
            int type = Convert.ToInt32(element.name.Substring(1,1));

            ObstacleScriptable newData = new ObstacleScriptable();
            newData.pos = element.position;
            newData.type = type;
            newData.name = intName;
            ObstacleScriptable nx = obstacles.Find(x => x.pos == newData.pos);
            if (nx == null)
            {
                obstacles.Add(newData);
            }
        }
    }
    [Button]
    public void ChangeRoad()
    {

        for (int i = 0; i < tileRoad.childCount; i++)
        {
            int indexPath = Convert.ToInt32(tileRoad.GetChild(i).name.Substring(4, 1));
            listWave.paths[indexPath].path[i] = (Vector2)tileRoad.GetChild(i).position;
        }
    }

}
