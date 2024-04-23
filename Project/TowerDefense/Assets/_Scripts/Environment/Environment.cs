using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public ObstacleManager obstacleManager;
    public SpriteRenderer homeSprite;
    public SpriteRenderer bg;

    private LevelManager lvManager;
    private LevelScriptable dataCurLevel;

    public void Init()
    {
        lvManager = LevelManager.instance;
        dataCurLevel = lvManager.listLevel.levelList[lvManager.curIndex];
        Sprite spriteHome = lvManager.listLevel.homeSprites[dataCurLevel.homeSpriteIndex];
        homeSprite.sprite = spriteHome;
        Sprite spriteBg = lvManager.listLevel.bgColors[dataCurLevel.bgSpriteIndex];
        bg.sprite = spriteBg;

        SetupObstacles();
    }
    public void SetupObstacles()
    {
        obstacleManager.SetListObstacle(lvManager.curIndex);
        obstacleManager.SpawnListObstacle();
    }
}
