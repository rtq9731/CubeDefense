using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
public class TowerAttack_Laser : Attackable
{
    [SerializeField] ContactFilter2D attackFilter;
    private LineRenderer lr;
    private TowerScript tower;
    
    float timer = 0f;

    public void Awake()
    {
        lr = GetComponent<LineRenderer>();
        tower = GetComponent<TowerScript>(); 
    }

    public override void Attack(int damage, EnemyScript Target)
    {
        if(bCanAttack)
        {
            StartCoroutine(laserAttack(1f, damage));
        }
        bCanAttack = false;
        timer = 0f;
    }

    private void Update()
    {
        
        if(lr.startWidth >= 0)
        {
            timer += Time.deltaTime * GameManager.Instance.gameSpeed;
            lr.getpoin
        }
    }

    IEnumerator laserAttack(float attackTime, int damage, float tickTime = 0.25f)
    {
        
        List<Collider2D> list = new List<Collider2D>();
        while (lr.startWidth != 0)
        {
            GetComponent<PolygonCollider2D>().OverlapCollider(attackFilter, list);

            list.FindAll(x => x.GetComponent<EnemyHealth>() != null).ForEach(x =>
            {
                GetComponent<EnemyHealth>().Hit(damage);
            });

            yield return new WaitForSeconds(tickTime);
        }
    }
    
}
