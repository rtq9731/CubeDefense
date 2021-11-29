using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    protected bool bCanAttack = false;
    protected float attackCoolTime = 0f;

    public abstract void Attack(int damage, EnemyScript Target);
}
