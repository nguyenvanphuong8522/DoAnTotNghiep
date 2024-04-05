using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-10, 0, 0), Time.deltaTime * speed);
    }
}
