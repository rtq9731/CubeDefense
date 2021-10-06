using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    TowerDir towerDir = TowerDir.Center;
    TowerData data;
    EnemyScript target = null;

    private void OnEnable()
    {
        
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
