using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [SerializeField]
    int tier;
    [SerializeField]
    int HP;
    [SerializeField]
    float speed;
    [SerializeField]
    EnemyDirection dir;

    enum EnemyDirection
    {
        right,
        left
    }

    public void Damage(int damage)
    {
        HP -= damage;
    }
}
