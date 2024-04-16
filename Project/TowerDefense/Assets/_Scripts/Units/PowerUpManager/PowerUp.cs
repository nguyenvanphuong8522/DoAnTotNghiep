using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public virtual void TurnOn()
    {
        gameObject.SetActive(true);
    }

    public virtual void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
