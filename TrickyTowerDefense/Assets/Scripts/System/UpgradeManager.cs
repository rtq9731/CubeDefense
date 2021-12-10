using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public void UpgradeTower(TowerData.TowerType upgradeType)
    {
        switch (upgradeType)
        {
            case TowerData.TowerType.Grenadier:
                break;
            case TowerData.TowerType.Laser:
                break;
            case TowerData.TowerType.Acher:
                break;
            case TowerData.TowerType.Bullet:
                break;
            case TowerData.TowerType.Buff:
                break;
            default:
                break;
        }
    }
}
