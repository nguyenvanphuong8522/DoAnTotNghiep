using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoObjectPool : MonoBehaviour
{
    public ObjectPool objectPool;
    private void Start()
    {
        objectPool = ObjectPool.instance;
    }
    public void Spawn()
    {
        GameObject triangle = objectPool.Get(objectPool.pools[0]);
        triangle.transform.position = Vector3.zero;
        triangle.SetActive(true);
        StartCoroutine(DelayDestroy(triangle));
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }
    IEnumerator DelayDestroy(GameObject go)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        objectPool.Return(go, true);
    }
}
