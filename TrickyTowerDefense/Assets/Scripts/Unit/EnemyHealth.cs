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
            gameObject.SetActive(false);
        }
    }


    private void Awake()
    {
        _enemyScript = GetComponent<EnemyScript>();
    }

    private void OnDisable()
    {
        _enemyScript.OnEnmeyDeath();
    }

    private void Start()
    {
        _stageManager = GameManager.Instance.stageManager;
    }
}
