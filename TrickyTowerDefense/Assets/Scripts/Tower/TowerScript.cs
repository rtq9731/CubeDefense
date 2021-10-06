using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    TowerDir towerDir = TowerDir.Center;
    TowerData data;
    EnemyScript target = null;
    TowerManager towerManager = null;

    public float madeTime = 0f;

    private void Start()
    {
        towerManager = GameManager.Instance.towerManager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            TowerScript otherTower = collision.transform.GetComponent<TowerScript>();
            if(otherTower != null)
            {
                if(otherTower.data.Idx == data.Idx)
                {
                    towerManager.AddMergeReadyTower(this);
                }
            }
        }
    }

    private void OnEnable()
    {
        madeTime = Time.time;
        towerManager.GetTowerList()[1].Add(this);
    }

    private void OnDisable()
    {
        foreach (var item in towerManager.GetTowerList())
        {
            item.Remove(this);
        }
    }

    public TowerData.TowerGrade GetTowerGrade()
    {
        return data.TOWERGRADE;
    }

    public TowerData.TowerType GetTowerType()
    {
        return data.TOWERTYPE;
    }

    public int GetTowerIdx()
    {
        return data.Idx;
    }

    public void SetData(TowerData data)
    {
        this.data = data;
    }

    public void SetTarget(EnemyScript target)
    {
        this.target = target;
    }

}

enum TowerDir
{
    Left,
    Center,
    Right
}
