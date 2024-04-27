using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class DesignLevel : Singleton<DesignLevel>
{
    public ListLevelScriptable data;
    public int levelIndex;
    public int type;
    public NameObstacle nameObstacle;
    public GameObject prefabIndicator;
    private void Start()
    {
        foreach (var item in data.levels[levelIndex].listObstacle)
        {
            AddObstacle(item.pos);
        }
    }

    public List<ObstacleScriptable> obstacles;
    public List<GameObject> indicators;
#if UNITY_EDITOR
    [Button]
    public void Save()
    {
        data.levels[levelIndex].listObstacle = obstacles;
        EditorUtility.SetDirty(data);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
#endif
    private void OnMouseUp()
    {
        Vector3 newPos = ConvertToGridPos.instance.GetPosToBuild();
        if (Input.GetKey(KeyCode.D))
        {
            Delete(newPos);
            return;
        }
        AddObstacle(newPos);
    }
    private void Delete(Vector3 pos)
    {
        ObstacleScriptable x = obstacles.Find(x => x.pos == pos);
        GameObject indicator = indicators.Find(x => x.transform.position == pos);
        if (x != null)
        {
            obstacles.Remove(x);
        }
        if (indicator != null)
        {
            indicators.Remove(indicator);
            Destroy(indicator);
        }
    }

    private void AddObstacle(Vector3 pos)
    {
        ObstacleScriptable newObstacle = new ObstacleScriptable();
        newObstacle.type = type;
        newObstacle.name = nameObstacle;
        newObstacle.pos = pos;

        CheckAdd(newObstacle);
    }

    private void CheckAdd(ObstacleScriptable newObstacle)
    {
        ObstacleScriptable x = obstacles.Find(x => x.pos == newObstacle.pos);
        if (x == null)
        {
            obstacles.Add(newObstacle);
            Indicator(newObstacle.pos);
        }
    }
    public void Indicator(Vector3 pos)
    {
        GameObject indicator = Instantiate(prefabIndicator, pos, Quaternion.identity);
        indicators.Add(indicator);
    }


}
