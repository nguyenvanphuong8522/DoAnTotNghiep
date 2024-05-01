using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPowerUp : PowerUp
{
    private float timer = 3f;
    public CircleCollider2D colliderRange;
    public GameObject particle;
    public override void TurnOn()
    {
        base.TurnOn();
        StartCoroutine(DelayExplore());
    }
    private IEnumerator DelayExplore()
    {
        yield return new WaitForSeconds(timer);
        Explore();
        yield return new WaitForSeconds(3f);
        colliderRange.enabled = false;
        particle.SetActive(false);
        TurnOff();
    }

    private void Explore()
    {
        colliderRange.enabled = true;
        particle.SetActive(true);
    }
}
