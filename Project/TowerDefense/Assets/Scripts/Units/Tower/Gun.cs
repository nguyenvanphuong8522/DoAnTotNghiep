using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float rate;
    protected Coroutine coroutineAttack;
    public bool isAttacking;
    public Transform target;
    public Transform[] pointShoots;
    public int typeBullet;
    public bool isShootingObstacle;
    protected int indexPointShoot;
    [SerializeField]private int atk;

    public ParticleSystem[] effectShoots;
    private void OnEnable()
    {
        isAttacking = false;
        isShootingObstacle = false;
        indexPointShoot = 0;
    }
    public virtual void StartShoot()
    {
        StopShoot();
        isAttacking = true;
        coroutineAttack = StartCoroutine(RateShoot());
    }
    public virtual void StopShoot()
    {
        if (coroutineAttack != null)
        {
            StopCoroutine(coroutineAttack);
            isAttacking = false;
        }
    }
    public virtual IEnumerator RateShoot()
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
    public virtual void Shoot()
    {
        PlaySound();
        indexPointShoot = indexPointShoot < pointShoots.Length - 1 ? ++indexPointShoot : 0;
        GameObject bullet = ObjectPool.instance.Get(ObjectPool.instance.bullets[typeBullet]);
        bullet.transform.position =  pointShoots[indexPointShoot].position;
        effectShoots[indexPointShoot].Play();
        ProjectileMovement movement = bullet.GetComponent<ProjectileMovement>();
        ProjectileExplore explore = bullet.GetComponent<ProjectileExplore>();
        if (movement != null)
        {
            movement.SetTarget(target);
            explore.damage = atk;
        }
    }
    private void PlaySound()
    {
        AudioManager.instance.PlayShot(AudioManager.instance.gunShoots[0]);
    }
    protected void RotateToDirection()
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
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
