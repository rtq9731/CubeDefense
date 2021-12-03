using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    protected TowerScript _tower = null;
    protected bool bCanAttack = true;
    protected float attackCoolTime = 0f;
    protected float attackTimer = 0f;

    public abstract void Attack(float damage, EnemyScript target);
}
