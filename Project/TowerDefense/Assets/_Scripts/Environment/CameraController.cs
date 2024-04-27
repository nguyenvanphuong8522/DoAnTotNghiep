using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    private Vector3 hitPos;
    public BoxCollider2D box;
    private float screenAspect; 
    private float maxRight;
    private float maxHeight;
    private float minZoom;
    private float maxZoom;

    private void Awake()
    {
        screenAspect = (float)Screen.width / Screen.height;
        float y = (float)16 / 9;
        float size = 3.8f / (screenAspect / y);
        cam.orthographicSize = size;
        maxZoom = size;
        minZoom = size - 1;

        maxRight = box.size.x / 2;
        maxHeight = box.size.y / 2;
    }

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
            newPos.x = Mathf.Clamp(newPos.x, -maxRight + camHalfWidth, maxRight - camHalfWidth);
            newPos.y = Mathf.Clamp(newPos.y, -maxHeight + camHalfHeight, maxHeight - camHalfHeight);
            transform.position = newPos;
        }
        float size = cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel");
        size = Mathf.Clamp(size, minZoom, maxZoom);
        cam.orthographicSize = size;
    }
}