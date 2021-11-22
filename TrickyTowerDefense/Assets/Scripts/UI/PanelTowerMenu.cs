using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTowerMenu : MonoBehaviour
{
    [SerializeField] int towerPrice = 0;

    private List<int> oneTierTowerIdx = new List<int>();

    [SerializeField] Button btnTowerWiki = null;
    [SerializeField] GameObject panelWiki = null;
    [SerializeField] Toggle toggleTowerUpgrade = null;
    [SerializeField] GameObject panelUpgrade = null;

    private int NextTowerIdx = -1;

    private void Start()
    {
        foreach (var item in GameManager.Instance.towerData.GetTowerDatas().FindAll(x => x.TOWERGRADE == TowerData.TowerGrade.Common))
        {
            oneTierTowerIdx.Add(item.Idx);
        }

        btnTowerWiki.onClick.AddListener(() => panelWiki.SetActive(true));
        toggleTowerUpgrade.onValueChanged.AddListener(isOn => panelUpgrade.SetActive(isOn));
    }
}
