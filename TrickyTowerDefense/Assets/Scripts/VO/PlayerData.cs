using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : ISerializationCallbackReceiver
{
    private List<TowerScript> towers = new List<TowerScript>();
    [SerializeField] private List<TowerData> towerDatas = new List<TowerData>();
    [SerializeField] private int gold = 10;
    [SerializeField] private int round = 0;
    [SerializeField] private int hp = 0;
    [SerializeField] private float time = 0f;

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public int Round
    {
        get { return round; }
        set { round = value; }
    }

    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public float Time
    {
        get { return time; }
        set { time = value; }
    }

    public bool Buy(int price)
    {
        if (gold - price < 0)
            return false;

        gold -= price;
        return true;
    }

    public void AddTower(TowerScript tower)
    {
        towerDatas.Add(tower.TowerData);
    }

    public void OnBeforeSerialize()
    {
        for (int i = 0; i < towerDatas.Count; i++)
        {
            towerDatas[i].Position = towers[i].transform.position;
        }
    }

    public void OnAfterDeserialize()
    {

    }
}
