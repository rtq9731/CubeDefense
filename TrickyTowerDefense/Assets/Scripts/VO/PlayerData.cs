using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] private List<TowerData> towerDatas = new List<TowerData>();
    [SerializeField] private int gold = 0;
    [SerializeField] private int round = 0;

    public bool CanBuy(int price)
    {
        return gold - price >= 0 ? true : false;
    }

    public void Buy(int price)
    {
        if (gold - price <= 0)
            return;

        gold -= price;
    }

    public void AddTower(TowerData tower)
    {

    }
}
