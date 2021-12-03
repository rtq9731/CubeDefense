using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack_Bullet : Attackable
{
    private void Awake()
    {
        _tower = GetComponent<TowerScript>();
    }

    public override void Attack(float damage, EnemyScript target)
    {

    }

    private void Update()
    {
        if (!bCanAttack)
        {
            if (attackTimer >= attackCoolTime)
            {
                bCanAttack = true;
            }

            attackTimer += Time.deltaTime * GameManager.Instance.gameSpeed;
        }
    }
}
