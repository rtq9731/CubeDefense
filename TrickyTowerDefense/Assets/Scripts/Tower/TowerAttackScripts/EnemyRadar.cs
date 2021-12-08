using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    TowerScript _tower = null;

    private void Awake()
    {
        _tower = transform.GetComponentInParent<TowerScript>();
    }

    public void SetRange(float range)
    {
        GetComponent<CircleCollider2D>().radius = range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyScript target = collision.GetComponent<EnemyScript>();
            if (target != null)
            {
                _tower. Attack(target);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyScript target = collision.GetComponent<EnemyScript>();
            if (target != null)
            {
                _tower.RemoveTarget(target);
            }
        }
    }
}
