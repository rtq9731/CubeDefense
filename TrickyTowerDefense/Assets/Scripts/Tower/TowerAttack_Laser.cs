using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TowerAttack_Laser : Attackable
{
    private LineRenderer lr;
    private TowerScript tower;
    public void Awake()
    {
        lr = GetComponent<LineRenderer>();
        tower = GetComponent<TowerScript>(); 
    }

    public override void Attack(int damage, EnemyScript Target)
    {
        bCanAttack = false;

        
    }

    IEnumerator laserAttack(float attackTime, float damage)
    {

        yield return null;
    }
    
}
