using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [SerializeField]
    int tier;
    [SerializeField]
    float HP;
    [SerializeField]
    float speed;
    [SerializeField]
    EnemyDirection dir;

    enum EnemyDirection
    {
        right,
        left
    }

    public void Damage(float damage)
    {
        HP -= damage;
    }
}
