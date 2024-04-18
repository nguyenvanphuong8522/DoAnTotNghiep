using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float rate;
    private Coroutine coroutineAttack;
    public bool isAttacking = false;
    public Transform target;
    public Transform[] pointShoots;
    public int typeBullet;
    public bool isShootingObstacle = false;
    private int indexPointShoot = 0;
    public void StartShoot()
    {
        StopShoot();
        isAttacking = true;
        coroutineAttack = StartCoroutine(RateShoot());
    }
    public void StopShoot()
    {
        if (coroutineAttack != null)
        {
            StopCoroutine(coroutineAttack);
            isAttacking = false;
        }
    }
    public IEnumerator RateShoot()
    {
        float curTime = Time.time;
        while (isAttacking)
        {
            RotateToDirection();
            if (Time.time - curTime >= rate)
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
        indexPointShoot = indexPointShoot < pointShoots.Length - 1 ? ++indexPointShoot : 0;
        GameObject bullet = ObjectPool.instance.Get(ObjectPool.instance.bullets[typeBullet], pointShoots[indexPointShoot].position);
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
        Vector3 look = target.position - transform.position;
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void StartPinTarget()
    {
        StopShoot();
        isShootingObstacle = !isShootingObstacle;
    }
}
