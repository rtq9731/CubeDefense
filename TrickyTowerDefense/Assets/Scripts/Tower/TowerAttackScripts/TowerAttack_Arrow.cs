using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack_Arrow : Attackable
{
    TowerArrowPool _arrowPool = null;
    private void Awake()
    {
        tower = GetComponent<TowerScript>();
        towerType = TowerData.TowerType.Acher;
    }

    private void Start()
    {
        _arrowPool = FindObjectOfType<TowerArrowPool>();
    }

    public override void Attack(float damage, EnemyScript target)
    {
        _arrowPool.GetArrow(transform.position).Fire(target, damage, transform.localScale);
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
