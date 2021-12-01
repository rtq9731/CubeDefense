using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack_Laser : Attackable
{
    LineRenderer _lr = null;
    MeshCollider _meshCollider = null;

    int damage = 0;

    float _attackTime = 0f;
    float _tickTime = 0.25f;
    float _effectTimer = 0f;

    bool _isAttacking = false;

    List<EnemyScript> targets = new List<EnemyScript>();

    private void Awake()
    {
        _lr = GetComponent<LineRenderer>();
        _meshCollider = GetComponent<MeshCollider>();

        _attackTime = attackCoolTime; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targets.Add(collision.GetComponent<EnemyScript>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(targets.Contains(collision.GetComponent<EnemyScript>()))
            targets.Remove(collision.GetComponent<EnemyScript>());
        }
    }

    public override void Attack(int damage, EnemyScript target)
    {
        if (bCanAttack)
        {
            _lr.startWidth = transform.localScale.x;
            _lr.endWidth = transform.localScale.x;
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1, target.transform.position);
            _lr.BakeMesh(_meshCollider.sharedMesh, true);
        }
    }

    public void Attack(int damage, Transform target)
    {
        if (bCanAttack)
        {
            _lr.startWidth = transform.localScale.x;
            _lr.endWidth = transform.localScale.x;
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1, target.transform.position);
            _lr.BakeMesh(_meshCollider.sharedMesh, true);
            Debug.Log("¤¾¤·");
        }
    }

    private void Update()
    {
        if (!bCanAttack && !_isAttacking)
        {
            if (attackTimer >= attackCoolTime)
            {
                bCanAttack = true;
            }

            attackTimer += Time.deltaTime * GameManager.Instance.gameSpeed;
        }
        else if (!bCanAttack && _isAttacking)
        {
            if(_effectTimer % _tickTime == 0)
            {
                CheckAttack();
            }

            _effectTimer += Time.deltaTime * GameManager.Instance.gameSpeed;
        }
    }

    private void CheckAttack()
    {
        if (_effectTimer >= 1)
        {
            _lr.startWidth = transform.localScale.x / 2;
            _lr.endWidth = transform.localScale.x / 2;
        }
        else
        {
            _lr.startWidth = transform.localScale.x;
            _lr.endWidth = transform.localScale.x;
        }
        
        
    }
}
