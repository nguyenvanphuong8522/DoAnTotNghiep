using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirInfor
{
    public Sprite home;
    public Sprite bg;
    public List<ObstacleScriptable> listObstacle;
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
        obstacleManager.SpawnListObstacle(data.listObstacle);
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
