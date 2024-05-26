using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour, Ihealth
{
    public SkeletonAnimation animationSke;
    public List<TowerAttack> towerAttacks;
    public bool isUnderAttack = false;

    public float health { get; set; }
    public HealBar healBar { get; set; }
    public int maxHeal;
    public int coinDestroy;
    public BoxCollider2D boxSmall;

    private void OnEnable()
    {
        towerAttacks.Clear();
        isUnderAttack = false;
        health = maxHeal;
        healBar = GetComponent<HealBar>();
        GameEvent.returnLevel += ReturnToPool;
    }
    private void Update()
    {
        if (health <= 0)
        {
            SetDie();
        }
    }
    private Vector3 preClick;
    private void OnMouseDown()
    {
        preClick = ConvertToGridPos.instance.GetMousePos();
    }
    private void OnMouseUp()
    {
        Vector3 curClick = ConvertToGridPos.instance.GetMousePos();
        float distance = Vector3.Distance(curClick, preClick);
        if (!Utils.IsPointerOverUIElement() && distance <= 0.00001f)
        {
            if (Arrow.instance.obstacle == null)
            {
                Arrow.instance.obstacle = this;
                Arrow.instance.SetPos(transform.position);
                CheckStartShootObstacles();
            }
            else if (Arrow.instance.obstacle == this)
            {
                CheckStartShootObstacles();
                Arrow.instance.obstacle = null;
                Arrow.instance.HideArrow();
            }
            else if (Arrow.instance.obstacle != this)
            {
                Arrow.instance.obstacle.CheckStartShootObstacles();
                Arrow.instance.obstacle = this;
                Arrow.instance.obstacle.CheckStartShootObstacles();
                Arrow.instance.SetPos(transform.position);
            }
        }

    }
    public void CheckStartShootObstacles()
    {
        isUnderAttack = !isUnderAttack;
        boxSmall.isTrigger = false;

        if (towerAttacks.Count > 0)
        {
            foreach (TowerAttack element in towerAttacks)
            {
                CheckIsShootObstacle(element);
            }
        }
    }

    public void CheckIsShootObstacle(TowerAttack towerAttack)
    {
        towerAttack.ShootObstacle(transform, !towerAttack.gun.isShootingObstacle);
        Arrow.instance.Show(towerAttack.gun.isShootingObstacle);

        if(towerAttack.gun.isShootingObstacle)
        {
            animationSke.state.SetAnimation(0, "dame", true);
        }
        else
        {
            animationSke.state.SetAnimation(0, "indle", true);
        }

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        healBar.UpdateHealBar();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Bullet")) return;
        ProjectileExplore bulletExplore = col.gameObject.GetComponent<ProjectileExplore>();
        if (bulletExplore != null)
        {
            TakeDamage(bulletExplore.damage);
            bulletExplore.Explore();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        AddOrRemove(col);

        if (!col.gameObject.CompareTag("Bullet")) return;
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Snipper");
        if (col.gameObject.layer == LayerIgnoreRaycast)
        {
            ProjectileExplore bulletExplore = col.gameObject.GetComponent<ProjectileExplore>();
            if (bulletExplore != null)
            {
                TakeDamage(bulletExplore.damage * 0.1f);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        AddOrRemove(col, false);
    }

    private void AddOrRemove(Collider2D col, bool value = true)
    {
        if (!col.CompareTag("Tower")) return;

        TowerAttack towerAttack = col.gameObject.GetComponentInParent<TowerAttack>();
        if (towerAttack == null) return;

        if (value)
        {
            AddTowerAttack(towerAttack);
            return;
        }
        towerAttacks.Remove(towerAttack);
    }
    private void AddTowerAttack(TowerAttack towerAttack)
    {
        towerAttacks.Add(towerAttack);
        if (isUnderAttack)
        {
            towerAttack.ShootObstacle(transform);
        }
    }

    private void SetDie()
    {
        CheckDie();
        SpawnEffectDie();
        ReturnToPool();
    }
    public void CheckDie()
    {
        if (isUnderAttack)
        {
            foreach (TowerAttack element in towerAttacks)
            {
                element.ShootObstacle(transform, false);
            }
        }
        Arrow.instance.HideArrow();
        LevelManager.instance.curLevel.IncreaseCoin(coinDestroy);
    }
    private void SpawnEffectDie()
    {
        Debug.Log("die");
        GameObject die = ObjectPool.instance.Get(ObjectPool.instance.obstacleDestroys[0], transform.position);
        SpawnDollarEffect();
    }
    public void ReturnToPool()
    {
        ObjectPool.instance.Return(gameObject);
    }

    private void SpawnDollarEffect()
    {
        GameObject effect = ObjectPool.instance.Get(ObjectPool.instance.effectDollar);
        effect.GetComponent<EffectDollar>().SetText(coinDestroy);
        effect.transform.position = transform.position + new Vector3(0, 0.75f, 0);
        effect.transform.localScale = Vector3.one * 0.1f;
        effect.SetActive(true);
    }
    private void OnDisable()
    {
        GameEvent.returnLevel -= ReturnToPool;
    }
}
