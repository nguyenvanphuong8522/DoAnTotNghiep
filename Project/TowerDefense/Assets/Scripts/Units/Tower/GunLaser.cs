using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLaser : Gun
{
    public Ihealth enemyHealth;
    public LineRenderer line;
    public AudioSource source;
    private void OnEnable()
    {
        HideLine();
    }
    public override void Shoot()
    {
        enemyHealth.TakeDamage(atk);
    }
    public override void StartShoot()
    {
        base.StartShoot();
        source.Play();
        line.enabled = true;
    }
    public override void StopShoot()
    {
        if (coroutineAttack != null)
        {
            StopCoroutine(coroutineAttack);
            isAttacking = false;
            source.Stop();
            HideLine();
        }
    }
    private void HideLine()
    {
        line.enabled = false;
    }
    public override void SetTarget(Transform target)
    {
        base.SetTarget(target);
        enemyHealth = target.GetComponent<Ihealth>();
    }
    public void UpdateLinePos()
    {
        if(target == null)
        {
            HideLine();
        }
        Vector3 newPos = target != null ? target.position : transform.position;
        newPos.z = -3;
        line.SetPosition(1, newPos);
        Vector3 newPos2 = pointShoots[0].position;
        newPos2.z = -3;
        line.SetPosition(0, newPos2);
    }
    public override IEnumerator RateShoot()
    {
        float curTime = Time.time;
        while (isAttacking)
        {
            RotateToDirection();
            UpdateLinePos();
            if (Time.time - curTime >= rate)
            {
                Shoot();
                curTime = Time.time;
            }
            yield return null;
        }
    }
}
