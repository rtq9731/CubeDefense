using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack_Laser : Attackable
{
    LineRenderer _lr = null;
    PolygonCollider2D _polygonCollider = null;

    int damage = 0;

    float _effectTime = 0f;
    float _tickTime = 0.25f;
    float _tickTimer = 0f;
    float _effectTimer = 0f;

    bool _isAttacking = false;

    List<EnemyScript> targets = new List<EnemyScript>();
    List<Vector2> colliderPostions = new List<Vector2>();

    private void Awake()
    {
        _tower = GetComponent<TowerScript>();
        _lr = GetComponent<LineRenderer>();
        _polygonCollider = GetComponent<PolygonCollider2D>();

        _effectTime = 4f; 
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

    public override void Attack(float damage, EnemyScript target)
    {
        if (bCanAttack)
        {
            targets = new List<EnemyScript>();
            _lr.startWidth = transform.localScale.x;
            _lr.endWidth = transform.localScale.x;
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1, target.transform.position);
            attackTimer = 0f;
            _effectTimer = 0f;
            _tickTimer = 0f;
            bCanAttack = false;
            _isAttacking = true;
        }
    }

    public void Attack(int damage, Transform target)
    {
        if (bCanAttack)
        {
            _lr.startWidth = transform.localScale.x;
            _lr.endWidth = transform.localScale.x;
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z));
            attackTimer = 0f;
            _effectTimer = 0f;
            _tickTimer = 0f;
            bCanAttack = false;
            _isAttacking = true;
        }
    }

    private void Update()
    {
        colliderPostions = GeneratePolygonCollider();
        _polygonCollider.SetPath(0, colliderPostions.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));

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
            if (_tickTimer >= _tickTime)
            {
                CheckAttack();
                _tickTimer = 0f;
            }

            if (_effectTimer >= _effectTime)
            {
                _isAttacking = false;
            }

            _effectTimer += Time.deltaTime * GameManager.Instance.gameSpeed;
            _tickTimer += Time.deltaTime * GameManager.Instance.gameSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        if (colliderPostions != null) colliderPostions.ForEach(p => Gizmos.DrawSphere(p, 0.1f)); 
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

        //if(targets.Count >= 1)
        //{
        //    targets.ForEach(x => x.Hit(_tower.TowerData.Atk));
        //}
    }

    private List<Vector2> GeneratePolygonCollider()
    {
        Vector3[] positions = new Vector3[_lr.positionCount];
        _lr.GetPositions(positions);

        float w = _lr.startWidth;

        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (w / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (w / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

        Vector3[] offsets = new Vector3[2];
        offsets[0] = new Vector3(-deltaX, deltaY);
        offsets[1] = new Vector3(deltaX, -deltaY);

        List<Vector2> colliderPositions = new List<Vector2>
        {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return colliderPositions;
    }
}
