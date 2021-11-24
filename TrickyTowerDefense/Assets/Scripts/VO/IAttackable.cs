using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    protected bool bCanAttack = false;
    protected float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime * GameManager.Instance.gameSpeed;
    }

    public abstract void Attack(int damage, EnemyScript Target);
}
