using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    TowerScript _tower = null;

    private void Awake()
    {
        _tower = GetComponent<TowerScript>();
    }

    private void OnEnable()
    {
        Debug.Log(_tower.TowerData.Range);
        GetComponents<CircleCollider2D>()[1].radius = _tower.TowerData.Range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        // 레이저 타워의 경우를 해결할 필요가 있슴.
        if (collision.CompareTag("Enemy"))
        {
            EnemyScript target = collision.GetComponent<EnemyScript>();
            if(target != null)
            {
                _tower.Attack(target);
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
