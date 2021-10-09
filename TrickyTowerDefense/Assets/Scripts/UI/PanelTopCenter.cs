using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTopCenter : MonoBehaviour
{
    [SerializeField] int towerPrice = 0;

    [SerializeField] PanelNextTower panelNextTower = null;

    private List<int> oneTierTowerIdx = new List<int>();

    [SerializeField] Button btnTowerWiki = null;
    [SerializeField] GameObject panelWiki = null;
    [SerializeField] Toggle toggleTowerUpgrade = null;
    [SerializeField] GameObject panelUpgrade = null;
    [SerializeField] Button btnOption = null;

    [SerializeField] Button btnBuyTower = null;

    private int NextTowerIdx = -1;

    private void Start()
    {
        foreach (var item in GameManager.Instance.tower.GetTowerDatas().FindAll(x => x.TOWERGRADE == TowerData.TowerGrade.Common))
        {
            Debug.Log(item.Idx);
            oneTierTowerIdx.Add(item.Idx);
        }

        btnTowerWiki.onClick.AddListener(() => panelWiki.SetActive(true));
        toggleTowerUpgrade.onValueChanged.AddListener(isOn => panelUpgrade.SetActive(isOn));
        btnBuyTower.onClick.AddListener(BuyTower);
    }

    private void BuyTower()
    {
        if(NextTowerIdx == -1)
        {
            NextTowerIdx = oneTierTowerIdx[Random.Range(0, oneTierTowerIdx.Count)];
            panelNextTower.SetNewTowerImage(NextTowerIdx);
        }

        if (GameManager.Instance.GetData().CanBuy(towerPrice))
        {
            GameManager.Instance.GetData().Buy(towerPrice);
            GameManager.Instance.towerManager.GetNewTower(NextTowerIdx);
            NextTowerIdx = oneTierTowerIdx[Random.Range(0, oneTierTowerIdx.Count)];
            panelNextTower.SetNewTowerImage(NextTowerIdx);
        }
    }
}
