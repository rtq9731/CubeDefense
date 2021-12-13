using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHitable
{
    EnemyScript _enemyScript = null;
    StageManager _stageManager = null;

    public void Hit(float damage)
    {
        _enemyScript.Data.Damage(damage);
        if(_enemyScript.Data.Hp <= 0)
        {
            _stageManager.PlusGold++;

            if(_enemyScript.Data.Tier > 0)
            {
                Vector3 enemyPos = transform.position;
                EnemyManager enemyManager = GameManager.Instance.enemyManager;
                enemyManager.SpawnEnemy(transform.position.x >= 0 ? Vector2.right : Vector2.left, _enemyScript.Data.Tier - 1).transform.position = enemyPos + Vector3.right * 0.5f;
                enemyManager.SpawnEnemy(transform.position.x >= 0 ? Vector2.right : Vector2.left, _enemyScript.Data.Tier - 1).transform.position = enemyPos + Vector3.left * 0.5f;
            }

            gameObject.SetActive(false);
        }
    }


    private void OnEnable()
    {
        _enemyScript = GetComponent<EnemyScript>();
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            _enemyScript.OnEnmeyDeath();
        }
    }

    private void Start()
    {
        _stageManager = GameManager.Instance.stageManager;
    }
}
