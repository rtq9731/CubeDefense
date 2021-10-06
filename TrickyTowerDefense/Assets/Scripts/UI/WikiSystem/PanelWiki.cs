using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelWiki : MonoBehaviour
{
    [SerializeField] PanelInfo panelInfo = null;
    [SerializeField] GameObject wikiIconPrefab;
    [SerializeField] Toggle toggleAllTower;
    [SerializeField] Toggle toggleGrenadierTower;
    [SerializeField] Toggle toggleLaserTower;
    [SerializeField] Toggle ToggleAcherTower;
    [SerializeField] Toggle ToggleBulletTower;
    [SerializeField] Toggle ToggleBuffTower;

    List<TowerData> towerDatas = new List<TowerData>();
    List<GameObject> icons = new List<GameObject>();

    private void Start()
    {
        towerDatas = GameManager.Instance.tower.GetTowerDatas();
        for (int i = 0; i < towerDatas.Count; i++)
        {
            GameObject tmp = Instantiate(wikiIconPrefab);
            tmp.GetComponent<TowerWikiIconElement>().Init(towerDatas[i]);
            icons.Add(tmp);
        }

        toggleAllTower.onValueChanged.AddListener(isOn =>
        {
            if(isOn)
            {
                icons.ForEach(x => x.SetActive(isOn));
            }
        });

        toggleGrenadierTower.onValueChanged.AddListener(isOn =>
        {
            if (isOn)
            {
                
            }
        });

    }

    

}