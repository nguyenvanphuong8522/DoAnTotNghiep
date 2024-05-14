using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadTile : MonoBehaviour
{
    [SerializeField]
    private Tilemap tileMap;

    public TileBase tileBase;

    public List<Vector3Int> listPos;
    private void OnEnable()
    {
        GameEvent.returnLevel += ClearTile;
    }
    public void ClearTile()
    {
        RemoveListTile();
        listPos.Clear();
    }
    public void InitRoad(List<Path> listPath)
    {
        foreach(var item in listPath)
        {
            SetTilesPos(item.path);
        }
        
        SetListTile();
    }

    public void SetTile(Vector3Int pos)
    {
        tileMap.SetTile(pos, tileBase);
    }

    public void RemoveTile(Vector3Int pos)
    {
        tileMap.SetTile(pos, null);
    }
    public void SetListTile()
    {
        foreach (var item in listPos)
        {
            SetTile(item);
        }
    }
    private void RemoveListTile()
    {
        foreach (var item in listPos)
        {
            RemoveTile(item);
        }
    }

    public void SetTilesPos(Vector2[] arr)
    {
        Vector3Int[] newArr = ConvertToVector3Int(arr);
        Vector3Int point = newArr[0];
        int index = 1;
        AddPoint(point);
        while(index < newArr.Length)
        {
            Vector3Int step = newArr[index] - point;
            step = ClampStep(step);
            point += step;
            AddPoint(point);

            if (point == newArr[index])
            {
                index++;
            }
        }
    }
    private void AddPoint(Vector3Int point)
    {
        if (!listPos.Contains(point))
        {
            listPos.Add(point);
        }
    }
    private Vector3Int ClampStep(Vector3Int direct)
    {
        direct.x = Mathf.Clamp(direct.x, -1, 1);
        direct.y = Mathf.Clamp(direct.y, -1, 1);
        return direct;
    }
    private Vector3Int[] ConvertToVector3Int(Vector2[] arr)
    {
        Vector3Int[] newArr = new Vector3Int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            Vector3 newPos = arr[i] - Vector2.one * 0.5f;
            newArr[i] = new Vector3Int((int)newPos.x, (int)newPos.y);
        }
        return newArr;
    }
    private void OnDisable()
    {
        GameEvent.returnLevel -= ClearTile;
    }

}
