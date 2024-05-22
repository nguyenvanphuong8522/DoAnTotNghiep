using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPowerUp : PowerUp
{
    private float timer = 5f;
    public CircleCollider2D colliderRange;
    public GameObject particle;
    public GameObject icon;
    public override void TurnOn()
    {
        base.TurnOn();
        icon.SetActive(true);
        StartCoroutine(DelayExplore());
    }
    private IEnumerator DelayExplore()
    {
        yield return new WaitForSeconds(timer);
        Explore();
        yield return new WaitForSeconds(0.2f);
        colliderRange.enabled = false;
        yield return new WaitForSeconds(5f);
        particle.SetActive(false);
        TurnOff();
    }

    private void Explore()
    {
        icon.SetActive(false);
        colliderRange.enabled = true;
        particle.SetActive(true);
    }
}
