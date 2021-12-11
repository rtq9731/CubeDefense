using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] int upgradePrice = 2;
    Dictionary<TowerData.TowerType, Button> buttonDict = new Dictionary<TowerData.TowerType, Button>();

    PlayerData data = null;
    PanelInfoTexts _infoTexts = null;

    private void Start()
    {
        data = GameManager.Instance.GetData();
        _infoTexts = GameManager.Instance.uiManager.infoTexts;
        buttonDict.Add(TowerData.TowerType.Grenadier, transform.Find("BtnGrenadierUpgrade").GetComponent<Button>());
        buttonDict.Add(TowerData.TowerType.Laser, transform.Find("BtnAcherUpgrade").GetComponent<Button>());
        buttonDict.Add(TowerData.TowerType.Acher, transform.Find("BtnBulletUpgrade").GetComponent<Button>());
        buttonDict.Add(TowerData.TowerType.Bullet, transform.Find("BtnLaserUpgrade").GetComponent<Button>());
        buttonDict.Add(TowerData.TowerType.Buff, transform.Find("BtnBuffUpgrade").GetComponent<Button>());

        buttonDict[TowerData.TowerType.Grenadier].onClick.AddListener(() => UpgradeTower(TowerData.TowerType.Grenadier));
        buttonDict[TowerData.TowerType.Laser].onClick.AddListener(() => UpgradeTower(TowerData.TowerType.Laser));
        buttonDict[TowerData.TowerType.Acher].onClick.AddListener(() => UpgradeTower(TowerData.TowerType.Acher));
        buttonDict[TowerData.TowerType.Bullet].onClick.AddListener(() => UpgradeTower(TowerData.TowerType.Bullet));
        buttonDict[TowerData.TowerType.Buff].onClick.AddListener(() => UpgradeTower(TowerData.TowerType.Buff));
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        buttonDict[TowerData.TowerType.Grenadier].GetComponentInChildren<Text>().text = 
            $"폭탄 타워\n업그레이드\n(+ {data.UpgradeCountDict[TowerData.TowerType.Grenadier]})\n(- {data.UpgradePriceDict[TowerData.TowerType.Grenadier]} Gold)";
        buttonDict[TowerData.TowerType.Laser].GetComponentInChildren<Text>().text =
            $"레이저 타워\n업그레이드\n(+ {data.UpgradeCountDict[TowerData.TowerType.Laser]})\n(- {data.UpgradePriceDict[TowerData.TowerType.Laser]} Gold)";
        buttonDict[TowerData.TowerType.Acher].GetComponentInChildren<Text>().text =
            $"화살 타워\n업그레이드\n(+ {data.UpgradeCountDict[TowerData.TowerType.Acher]})\n(- {data.UpgradePriceDict[TowerData.TowerType.Acher]} Gold)";
        buttonDict[TowerData.TowerType.Bullet].GetComponentInChildren<Text>().text =
            $"탄환 타워\n업그레이드\n(+ {data.UpgradeCountDict[TowerData.TowerType.Bullet]})\n(- {data.UpgradePriceDict[TowerData.TowerType.Bullet]} Gold)";
        buttonDict[TowerData.TowerType.Buff].GetComponentInChildren<Text>().text =
            $"버프 타워\n업그레이드\n(+ {data.UpgradeCountDict[TowerData.TowerType.Buff]})\n(- {data.UpgradePriceDict[TowerData.TowerType.Buff]} Gold)";
        _infoTexts.UpdateTexts();
    }

    public void UpgradeTower(TowerData.TowerType upgradeType)
    {
        switch (upgradeType)
        {
            case TowerData.TowerType.Grenadier:
                if (data.Buy(data.UpgradePriceDict[TowerData.TowerType.Grenadier]))
                {
                    data.UpgradeCountDict[TowerData.TowerType.Grenadier] += 2;
                    data.UpgradePriceDict[TowerData.TowerType.Grenadier] += 2;
                }
                break;
            case TowerData.TowerType.Laser:
                if (data.Buy(data.UpgradePriceDict[TowerData.TowerType.Laser]))
                {
                    data.UpgradeCountDict[TowerData.TowerType.Laser] += 2;
                    data.UpgradePriceDict[TowerData.TowerType.Laser] += 2;
                }
                break;
            case TowerData.TowerType.Acher:
                if (data.Buy(data.UpgradePriceDict[TowerData.TowerType.Acher]))
                {
                    data.UpgradeCountDict[TowerData.TowerType.Acher] += 2;
                    data.UpgradePriceDict[TowerData.TowerType.Acher] += 2;
                }
                break;
            case TowerData.TowerType.Bullet:
                if (data.Buy(data.UpgradePriceDict[TowerData.TowerType.Bullet]))
                {
                    data.UpgradeCountDict[TowerData.TowerType.Bullet] += 2;
                    data.UpgradePriceDict[TowerData.TowerType.Bullet] += 2;
                }
                break;
            case TowerData.TowerType.Buff:
                if (data.Buy(data.UpgradePriceDict[TowerData.TowerType.Buff]))
                {
                    data.UpgradeCountDict[TowerData.TowerType.Buff] += 2;
                    data.UpgradePriceDict[TowerData.TowerType.Buff] += 2;
                }
                break;
            default:
                break;
        }
        UpdateTexts();
    }
}
