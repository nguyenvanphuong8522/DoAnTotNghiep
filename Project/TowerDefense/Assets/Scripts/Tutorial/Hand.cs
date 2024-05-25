using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private Transform bound;

    public void SetPosHand(Vector3 pos)
    {
        hand.position = pos;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void SetBound(Vector3 pos)
    {
        bound.position = pos;
    }
}
