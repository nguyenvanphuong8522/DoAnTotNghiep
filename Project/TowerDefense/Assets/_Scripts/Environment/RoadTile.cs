using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadTile : MonoBehaviour
{
    [SerializeField]
    private Tilemap tileMap;
    private TileBase tileBase;

    public List<Vector3Int> listPos;

    public void SetTile(Vector3Int pos)
    {
        tileMap.SetTile(pos, tileBase);
    }

    public void RemoveTile(Vector3Int pos)
    {
        tileMap.SetTile(pos, null);
    }
}
