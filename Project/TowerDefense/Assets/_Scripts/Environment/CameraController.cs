using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    private Vector3 hitPos;
    private float screenAspect = (float)Screen.width / Screen.height;

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
            
            float camHalfHeight = cam.orthographicSize;
            float camHalfWidth = camHalfHeight * screenAspect;
            newPos.x = Mathf.Clamp(newPos.x, -14 + camHalfWidth, 14 - camHalfWidth);
            newPos.y = Mathf.Clamp(newPos.y, -10 + camHalfHeight, 5 - camHalfHeight);
            transform.position = newPos;
        }

        cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
    }
}