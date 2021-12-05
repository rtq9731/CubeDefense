using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHitable
{
    EnemyScript enemyScript = null;

    public void Hit(float damage)
    {
        enemyScript.Data.Damage(damage);
        if(enemyScript.Data.Hp <= 0)
        {
            enemyScript.onEnemyDeath();
            gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
    }
}
