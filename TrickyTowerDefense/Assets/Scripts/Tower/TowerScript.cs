using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerScript : MonoBehaviour
{
    TowerMerge towerMerge = null;
    Attackable towerAttack = null;

    EnemyScript target = null;
    TowerManager towerManager = null;
    TowerPosChecker towerPosChecker = null;
    TowerData towerData = new TowerData();

    private bool isRanded = false; // ¶¥¿¡ ¶³¾îÁ³´Â°¡?

    public bool IsRanded
    {
        get { return isRanded; }
        set { isRanded = value; }
    }

    public TowerData TowerData
    {
        get { return towerData; }
        set { towerData = value; }
    }

    public float madeTime = 0f;

    private void Awake()
    {
        towerAttack = GetComponent<Attackable>();
        towerPosChecker = GetComponent<TowerPosChecker>();
    }

    private void OnEnable()
    {
        if (towerManager == null)
        {
            towerManager = GameManager.Instance.towerManager;
        }

        madeTime = Time.time;
    }

    public void SetTarget(EnemyScript target)
    {
        this.target = target;
    }

}
