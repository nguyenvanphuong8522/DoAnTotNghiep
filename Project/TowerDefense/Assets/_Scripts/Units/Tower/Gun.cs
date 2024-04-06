using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float duration;
    private Coroutine coroutineAttack;
    private bool isAttacking = false;
    public Transform target;

    private ObjectPool objectPool;
    
    private void Start()
    {
        objectPool = ObjectPool.instance;
    }

    public void StartShoot()
    {
        if(!isAttacking)
        {
            isAttacking = true;
            StopShoot();
            coroutineAttack = StartCoroutine(RateShoot());
        }
    }

    public void StopShoot()
    {
        if(coroutineAttack != null)
        {
            StopCoroutine(coroutineAttack);
            isAttacking = false;
        }
    }
    public IEnumerator RateShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(duration);
        }
    }
    private void Shoot()
    {
        PlaySound();
        GameObject bullet = objectPool.Get(objectPool.pools[0], transform.position, 0.3f);
        ProjectileMovement movement = bullet.GetComponent<ProjectileMovement>();
        if(movement != null)
        {
            movement.SetTarget(target);
        }
    }
    private void PlaySound()
    {
        AudioManager.instance.PlayShot(AudioManager.instance.gunShoots[0]);
    }
}
