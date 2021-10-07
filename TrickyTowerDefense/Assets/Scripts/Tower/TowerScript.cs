using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;

    TowerData data;
    EnemyScript target = null;
    TowerManager towerManager = null;

    public float madeTime = 0f;

    private void OnEnable()
    {
        if(towerManager == null)
        {
            towerManager = GameManager.Instance.towerManager;
        }

        madeTime = Time.time;
        towerManager.GetTowerList().Add(this);
    }

    private void OnDisable()
    {
        towerManager.GetTowerList().Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            TowerScript otherTower = collision.transform.GetComponent<TowerScript>();
            if (otherTower != null)
            {
                if (otherTower.data.Idx == data.Idx)
                {
                    towerManager.AddMergeReadyTower(this);
                }
            }
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
        sr.sprite = GameManager.Instance.tower.GetTowerSprite(data.TOWERTYPE, data.TOWERGRADE);
    }

    public void SetTarget(EnemyScript target)
    {
        this.target = target;
    }

}
