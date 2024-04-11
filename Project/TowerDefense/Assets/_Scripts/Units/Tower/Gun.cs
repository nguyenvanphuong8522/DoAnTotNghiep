using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float duration;
    private Coroutine coroutineAttack;
    private bool isAttacking = false;
    public Transform target;
    public Transform gun;
    public Transform pointShoot;
    public int typeBullet;

    public void StartShoot()
    {
        if (!isAttacking)
        {
            StopShoot();
            isAttacking = true;
            coroutineAttack = StartCoroutine(RateShoot());
        }
    }
    public void StopShoot()
    {
        if (coroutineAttack != null)
        {
            StopCoroutine(coroutineAttack);
        }
        isAttacking = false;
    }
    public IEnumerator RateShoot()
    {
        float curTime = Time.time;
        while (isAttacking)
        {
            RotateToDirection();
            if (Time.time - curTime >= duration)
            {
                Shoot();
                curTime = Time.time;
            }
            yield return null;
        }
    }
    private void Shoot()
    {
        PlaySound();
        GameObject bullet = ObjectPool.instance.Get(ObjectPool.instance.bullets[typeBullet], pointShoot.position);
        ProjectileMovement movement = bullet.GetComponent<ProjectileMovement>();
        if (movement != null)
        {
            movement.SetTarget(target);
        }
    }
    private void PlaySound()
    {
        AudioManager.instance.PlayShot(AudioManager.instance.gunShoots[0]);
    }
    private void RotateToDirection()
    {
        Vector3 look = target.position - gun.position;
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        gun.rotation = Quaternion.Euler(0, 0, angle);
    }
}
