using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    public GameObject canvas;
    public GameObject tileObstacle;
    public GameObject tileRoad;
    public GameObject designLevel;
    [Button]
    public void Game()
    {
        designLevel.SetActive(false);
        canvas.SetActive(true);
        tileObstacle.SetActive(false);
        tileRoad.SetActive(false);
    }
    [Button]
    public void Design()
    {
        designLevel.SetActive(true);
        canvas.SetActive(false);
        tileObstacle.SetActive(true);
        tileRoad.SetActive(true);
    }
}
