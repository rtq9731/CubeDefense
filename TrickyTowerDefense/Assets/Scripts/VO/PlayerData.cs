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
    [SerializeField]private Dictionary<TowerData.TowerType, int> upgradeCountDict = new Dictionary<TowerData.TowerType, int>() 
    { 
        { TowerData.TowerType.Grenadier, 0 }, 
        { TowerData.TowerType.Laser, 0 }, 
        { TowerData.TowerType.Acher, 0 }, 
        { TowerData.TowerType.Bullet, 0 }, 
        { TowerData.TowerType.Buff, 0 } 
    };


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

    public bool Buy(int price)
    {
        if (gold - price < 0)
            return false;

        gold -= price;
        return true;
    }

    public Dictionary<TowerData.TowerType, int> UpgradeCountDict
    {
        get { return upgradeCountDict; }
    }

    public List<TowerData> TowerDatas => towerDatas;

    public void OnBeforeSerialize()
    {
        towerDatas = GameManager.Instance.towerManager.GetAllLivingTowerData();
        for (int i = 0; i < towerDatas.Count; i++)
        {
            towerDatas[i].Position = towers[i].transform.position;
        }

    }

    public void OnAfterDeserialize()
    {

    }
}
