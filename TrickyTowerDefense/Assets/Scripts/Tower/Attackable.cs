using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    protected TowerData.TowerType towerType = TowerData.TowerType.Grenadier;
    protected TowerScript tower = null;
    protected bool bCanAttack = true;
    protected float attackCoolTime = 0f;
    protected float attackTimer = 0f;

    public TowerData.TowerType TowerType => towerType;
    public bool CanAttack => bCanAttack;

    public abstract void Attack(float damage, EnemyScript target);
    
    public void SetAttackCoolTime(float attackCoolTime)
    {
        this.attackCoolTime = attackCoolTime;
    }
}
