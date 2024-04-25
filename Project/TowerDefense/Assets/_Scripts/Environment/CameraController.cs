using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    private Vector3 hitPos;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hitPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 direction = cam.ScreenToWorldPoint(Input.mousePosition) - hitPos;
            Vector3 newPos = transform.position - direction;
            newPos.x = Mathf.Clamp(newPos.x, -2.5f, 4.5f);
            transform.position = newPos;
        }

        cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
    }
}