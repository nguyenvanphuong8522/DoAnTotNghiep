using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadTile : MonoBehaviour
{
    [SerializeField]
    private Tilemap tileMap;
    private TileBase tileBase;

    public List<Vector3Int> listPos;
    public Vector2[] arr;
    private void Start()
    {
        ConvertToListPos(arr);
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

    public void ConvertToListPos(Vector2[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
        }
    }

    public void AddToBetweenPoint()
    {

    }
}
