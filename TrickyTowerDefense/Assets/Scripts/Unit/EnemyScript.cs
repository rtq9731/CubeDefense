using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    EnemyData data = new EnemyData();
    EnemyHealth health = null;

    public Action onEnemyDeath = () => { };

    public EnemyData Data
    {
        get { return data; }
    }

    private void OnEnable()
    {
        onEnemyDeath = () => { }; // 연결된 이벤트 전부 초기화
    }

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
    }

    public void Hit(float damage)
    {
        health.Hit(damage);
    }
}
