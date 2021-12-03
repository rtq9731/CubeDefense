using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    EnemyData data = new EnemyData();
    EnemyHealth health = null;

    public EnemyData Data
    {
        get { return data; }
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
