using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private List<TowerScript> towers = new List<TowerScript>();
    [SerializeField] private List<TowerData> towerDatas = new List<TowerData>();
    [SerializeField] private int gold = 10;
    [SerializeField] private int round = 0;
    [SerializeField] private int hp = 100;

    [SerializeField] private Dictionary<TowerData.TowerType, int> upgradeCountDict = new Dictionary<TowerData.TowerType, int>()
    { 
        { TowerData.TowerType.Grenadier, 0 }, 
        { TowerData.TowerType.Laser, 0 }, 
        { TowerData.TowerType.Acher, 0 }, 
        { TowerData.TowerType.Bullet, 0 }, 
        { TowerData.TowerType.Buff, 0 } 
    };

    [SerializeField] private Dictionary<TowerData.TowerType, int> upgradePriceDict = new Dictionary<TowerData.TowerType, int>()
    {
        { TowerData.TowerType.Grenadier, 1 },
        { TowerData.TowerType.Laser, 1 },
        { TowerData.TowerType.Acher, 1 },
        { TowerData.TowerType.Bullet, 1 },
        { TowerData.TowerType.Buff, 1 }
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
        set { 
            hp = value;
            if (hp <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    public bool Buy(int price)
    {
        if (gold - price < 0)
            return false;

        gold -= price;
        GameManager.Instance.uiManager.infoTexts.UpdateTexts();

        Vector3 textPos = GameManager.Instance.uiManager.infoTexts.textCurGold.transform.position;
        textPos.x += 100;

        GameManager.Instance.textEffectManager.GetTextEffect
            ($"- {price}", 
            Color.black,
            textPos, 
            true);

        return true;
    }

    public Dictionary<TowerData.TowerType, int> UpgradeCountDict
    {
        get { return upgradeCountDict; }
    }

    public Dictionary<TowerData.TowerType, int> UpgradePriceDict
    {
        get { return upgradePriceDict; }
    }

    public List<TowerScript> Towers
    {
        get { return towers; }
        set { towers = value; }
    }

    public List<TowerData> TowerDatas
    {
        get { return towerDatas; }
        set { towerDatas = value; }
    }
}
