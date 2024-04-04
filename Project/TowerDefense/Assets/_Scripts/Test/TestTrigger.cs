using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogError("Triggered");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.LogError("Collisioned");
    }
}
