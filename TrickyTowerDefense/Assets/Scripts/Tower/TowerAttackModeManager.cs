using 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackModeManager : MonoBehaviour
{
    private Dictionary<TowerData.TowerType, Attackable> attackTypeDict = new Dictionary<TowerData.TowerType, Attackable>();

    TowerData.TowerType attackType = TowerData.TowerType.Grenadier;

    TowerScript _tower = null;

    private void Awake()
    {
        _tower = transform.parent.GetComponent<TowerScript>();
        foreach (var item in GetComponents<Attackable>())
        {
            attackTypeDict.Add(_tower.TowerData.TOWERTYPE, item);
        }
    }

    private void OnEnable()
    {
        SwitchMode(_tower.TowerData.TOWERTYPE);
    }

    public void SwitchMode(TowerData.TowerType towerType)
    {
        foreach (var item in attackTypeDict.Values)
        {
            item.enabled = false;
        }
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;

        switch (towerType)
        {
            case TowerData.TowerType.Laser:
                attackTypeDict[towerType].enabled = true;
                GetComponent<LineRenderer>().enabled = true;
                GetComponent<PolygonCollider2D>().enabled = true;
                break;
            case TowerData.TowerType.Grenadier:
            case TowerData.TowerType.Acher:
            case TowerData.TowerType.Bullet:
            case TowerData.TowerType.Buff:
                attackTypeDict[towerType].enabled = true;
                break;
            default:
                break;
        }
    }

}
