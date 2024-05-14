using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirInfor
{
    public Sprite home;
    public Sprite bg;
    public List<ObstacleScriptable> listObstacle;
    public List<Path> arr;
    public Vector3 posHouse;
}
public class Environment : MonoBehaviour
{
    public ObstacleManager obstacleManager;
    public RoadTile roadTile;

    public SpriteRenderer homeSprite;
    public SpriteRenderer bgSprite;

    public void Init(EnvirInfor data)
    {
        UpdateSpriteBG(data.bg);
        UpdateSpriteHome(data.home);
        homeSprite.transform.position = data.posHouse;
        obstacleManager.SpawnListObstacle(data.listObstacle);
        roadTile.InitRoad(data.arr);
    }

    public void UpdateSpriteBG(Sprite sprite)
    {
        bgSprite.sprite = sprite;
    }
    public void UpdateSpriteHome(Sprite sprite)
    {
        homeSprite.sprite = sprite;
    }
}
