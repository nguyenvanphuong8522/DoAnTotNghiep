using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPowerUp : PowerUp
{
    private float duration = 20f;
    public override void TurnOn()
    {
        gameObject.SetActive(true);
        StartCoroutine(DelayTurnOff());
    }
    public IEnumerator DelayTurnOff()
    {
        yield return new WaitForSeconds(duration);
        TurnOff();
    }
}
