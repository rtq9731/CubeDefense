using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack_Grenade : Attackable
{
    TowerGrenadePool _GrenadePool = null;
    private void Awake()
    {
        tower = transform.parent.GetComponent<TowerScript>();
        towerType = TowerData.TowerType.Grenadier;
    }

    private void Start()
    {
        _GrenadePool = FindObjectOfType<TowerGrenadePool>();
    }

    public override void Attack(float damage, EnemyScript target)
    {
        if (!bCanAttack)
            return;

        _GrenadePool.GetGrenade(transform.position).Fire(target, damage, transform.localScale, tower.TowerData.Splashrange);
        bCanAttack = false;
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
