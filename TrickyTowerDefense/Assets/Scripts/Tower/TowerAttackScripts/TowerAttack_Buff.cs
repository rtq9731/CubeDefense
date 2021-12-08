using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack_Buff : Attackable
{
    TowerScript _tower = null;
    List<TowerScript> towersInBuff = new List<TowerScript>();

    public override void Attack(float damage, EnemyScript target)
    {
        return;
    }

    private void Awake()
    {
        towerType = TowerData.TowerType.Buff;
        _tower = transform.parent.GetComponent<TowerScript>();
    }

    private void OnEnable()
    {
        towersInBuff = new List<TowerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tower"))
        {
            TowerScript curTower = collision.gameObject.GetComponent<TowerScript>();
            if (curTower != null)
            {
                if (towersInBuff.Count < 2 && !towersInBuff.Contains(curTower))
                {
                    towersInBuff.Add(curTower);
                    curTower.TowerData.PlusATK += _tower.TowerData.Atk;
                }
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            TowerScript curTower = collision.gameObject.GetComponent<TowerScript>();
            if (curTower != null)
            {
                if (towersInBuff.Count < 2 && !towersInBuff.Contains(curTower))
                {
                    towersInBuff.Add(curTower);
                    curTower.TowerData.PlusATK += _tower.TowerData.Atk;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            TowerScript curTower = collision.gameObject.GetComponent<TowerScript>();
            if (curTower != null)
            {
                if(towersInBuff.Contains(curTower))
                {
                    towersInBuff.Remove(curTower);
                    curTower.TowerData.PlusATK -= _tower.TowerData.Atk;
                }
            }
        }
    }
}
