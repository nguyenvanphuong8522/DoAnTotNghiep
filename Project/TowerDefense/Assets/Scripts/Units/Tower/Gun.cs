using Spine.Unity;
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
    public int atk;
    float curTime = -100000;

    public ParticleSystem[] effectShoots;

    public SkeletonAnimation skeletonAnimation;

    public AudioClip soundEffect;
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
            skeletonAnimation.AnimationState.SetEmptyAnimation(0, 0);
        }
    }
    public virtual IEnumerator RateShoot()
    {
        
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
        RotateImediate();
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
        skeletonAnimation.state.SetAnimation(0, "animation", false);
    }
    private void PlaySound()
    {
        AudioManager.instance.PlayShot(soundEffect);
    }
    protected void RotateToDirection()
    {
        Vector3 look = target.position - transform.position;
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), 0.1f);
    }
    protected void RotateImediate()
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
