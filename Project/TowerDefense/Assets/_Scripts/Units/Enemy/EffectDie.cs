using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDie : MonoBehaviour
{
    public float duration;

    private void OnEnable()
    {
        StartCoroutine(DelayReturnPool());
    }
    private IEnumerator DelayReturnPool()
    {
        yield return new WaitForSeconds(duration);
        ObjectPool.instance.Return(gameObject);
    }
}
