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
    TowerData _data = new TowerData();

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
            _rader.SetRange(_data.Range);
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

    public void RemoveTarget(EnemyScript enemy)
    {
        _targetList.Remove(enemy);
    }

    private void Awake()
    {
        _rader = GetComponentInChildren<EnemyRadar>();
    }

    public void SetAttackMode(Attackable attack)
    {
        _towerAttack = attack;
    }

    private void Update()
    {
        if(_targetList.Count > 0)
        {
            if(_towerAttack.CanAttack)
            {
                _towerAttack.Attack(_data.Atk + _data.PlusATK, _targetList[0]);
            }
        }
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

}
