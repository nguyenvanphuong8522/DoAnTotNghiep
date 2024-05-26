using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Singleton<Arrow>
{
    public Obstacle obstacle;
    public GameObject arrow;
    public void SetPos(Vector3 pos)
    {
        transform.position = pos + Vector3.up * 1.2f;
    }
    public void HideArrow()
    {
        arrow.SetActive(false);
    }

    public void ShowArrow()
    {
        arrow.SetActive(true);
    }
    public void Show(bool value)
    {
        arrow.SetActive(value);
    }
    
}
