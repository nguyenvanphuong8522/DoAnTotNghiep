using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEffect : MonoBehaviour
{
    [SerializeField]private LineRenderer lineRenderer;


    public void AddPoint(Vector3 newPos)
    {
        lineRenderer.positionCount++;
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, newPos);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));
        worldPosition.z = 0;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPosition);
    }
    public void ClearPoints()
    {
        lineRenderer.positionCount = 0;
    }
}
