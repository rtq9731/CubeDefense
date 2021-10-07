using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] private List<TowerData> towerDatas = new List<TowerData>();
    [SerializeField] private int money = 0;

    public bool CanBuy(int price)
    {
        return money - price >= 0 ? true : false;
    }

    public void Buy(int price)
    {
        if (money - price <= 0)
            return;

        money -= price;
    }

    public void AddTower(TowerData tower)
    {

    }
}
