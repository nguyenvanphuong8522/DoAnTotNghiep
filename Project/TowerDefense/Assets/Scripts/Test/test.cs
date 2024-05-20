using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public RectTransform rect;

    [Button]
    public void Set()
    {
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, rect.position);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));
        transform.position = worldPosition;
    }
}
