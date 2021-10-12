using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;

    TowerData data;
    EnemyScript target = null;
    TowerManager towerManager = null;

    public Action<TowerScript> towerPosChanged = null;

    public float madeTime = 0f;

    private void Awake()
    {
        towerPosChanged += (x) => { }; // 액션 초기화
    }

    private void Start()
    {
        towerPosChanged += (x) => FindObjectOfType<TowerHeightChecker>().TowerHeightCheck(x);
    }

    private void OnEnable()
    {
        if(towerManager == null)
        {
            towerManager = GameManager.Instance.towerManager;
        }

        madeTime = Time.time;

        if (!towerManager.GetTowerList().Contains(this))
        {
            towerManager.GetTowerList().Add(this);
        }
    }

    private void OnDisable()
    {
        towerManager.GetTowerList().Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            if (data.TOWERGRADE == TowerData.TowerGrade.Legendary)
            {
                return;
            }

            TowerScript otherTower = collision.transform.GetComponent<TowerScript>();
            if (otherTower != null)
            {
                if (otherTower.data.Idx == data.Idx)
                {
                    towerManager.AddMergeReadyTower(this);
                    return;
                }
            }

            towerPosChanged(this);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            towerPosChanged(this);
        }
    }

    private void UpdateSize(TowerData.TowerGrade grade)
    {
        switch (grade)
        {
            case TowerData.TowerGrade.Common:
                transform.DOScale(1, 0.1f);
                break;
            case TowerData.TowerGrade.Uncommon:
                transform.DOScale(1.3f, 0.1f);
                break;
            case TowerData.TowerGrade.Rare:
                transform.DOScale(1.8f, 0.1f);
                break;
            case TowerData.TowerGrade.Epic:
                transform.DOScale(2.5f, 0.1f);
                break;
            case TowerData.TowerGrade.Unique:
                transform.DOScale(3.5f, 0.1f);
                break;
            case TowerData.TowerGrade.Legendary:
                transform.DOScale(5, 0.1f);
                break;
            default:
                break;
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
        UpdateSize(data.TOWERGRADE);
        sr.sprite = GameManager.Instance.tower.GetTowerSprite(data.TOWERTYPE, data.TOWERGRADE);
    }

    public void SetTarget(EnemyScript target)
    {
        this.target = target;
    }

}
