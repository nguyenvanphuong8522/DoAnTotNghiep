using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadTile : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase tileBase;

    public Vector3Int pos;
    [Button]
    public void SetTile()
    {
        tileMap.SetTile(pos, tileBase);
    }
    [Button]
    public void RemoveTile()
    {
        tileMap.SetTile(pos, null);
    }
}
