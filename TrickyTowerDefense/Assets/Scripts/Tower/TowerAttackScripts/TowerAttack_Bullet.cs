using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack_Bullet : Attackable
{
    TowerBulletPool _bulletPool = null;
    private void Awake()
    {
        tower = GetComponent<TowerScript>();
        towerType = TowerData.TowerType.Bullet;
    }

    private void Start()
    {
        _bulletPool = FindObjectOfType<TowerBulletPool>();
    }

    public override void Attack(float damage, EnemyScript target)
    {
        _bulletPool.GetBullet(transform.position).Fire(target, damage, transform.localScale);
    }

    private void Update()
    {
        if (!bCanAttack)
        {
            if (attackTimer >= attackCoolTime)
            {
                bCanAttack = true;
                attackTimer = 0f;
            }

            attackTimer += Time.deltaTime * GameManager.Instance.gameSpeed;
        }
    }
}
