using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerScript : MonoBehaviour
{
    Attackable _towerAttack = null;
    EnemyRadar _rader = null;
    TowerManager _towerManager = null;
    [SerializeField] TowerData _data = new TowerData();
    SpriteRenderer _sr = null;


    public List<EnemyScript> _targetList = new List<EnemyScript>();

    private bool isRanded = false; // ¶¥¿¡ ¶³¾îÁ³´Â°¡?

    public bool IsRanded
    {
        get { return isRanded; }
        set { isRanded = value; }
    }

    public TowerData TowerData
    {
        get { return _data; }

        set {
            _data = value; 
        }
    }

    public float madeTime = 0f;

    public void Attack(EnemyScript enemy)
    {
        if(!_targetList.Contains(enemy))
        {
            _targetList.Add(enemy);
            enemy.OnEnmeyDeath += () => { 
                _targetList.Remove(enemy);
            };
        }
    }

    private void Awake()
    {
        _rader = GetComponentInChildren<EnemyRadar>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (_towerManager == null)
        {
            _towerManager = GameManager.Instance.towerManager;
        }
        _targetList = new List<EnemyScript>();

        madeTime = Time.time;
    }

    private void Update()
    {
        if (_targetList.Count > 0)
        {
            if (_towerAttack.CanAttack)
            {
                _towerAttack.Attack(_data.Atk + _data.PlusATK + _data.Atk * (GameManager.Instance.GetData().UpgradeCountDict[_data.TOWERTYPE] / 100), _targetList[0]);
            }
        }
    }


    public void RemoveTarget(EnemyScript enemy)
    {
        _targetList.Remove(enemy);
    }

    public void SetAttackMode(Attackable attack)
    {
        _towerAttack = attack;
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

    public void SetData(TowerData data)
    {
        TowerData = data;
        _rader.SetRange(_data.Range);
        UpdateSize(data.TOWERGRADE);
        _sr.sprite = GameManager.Instance.towerData.GetTowerSprite(data.TOWERTYPE, data.TOWERGRADE);
    }
}
