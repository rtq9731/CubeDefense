using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerWikiIconElement : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image mySprite = null;

    [HideInInspector] public Button btn;
    [HideInInspector] public TowerData data;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    public void Init(TowerData data, PanelInfo panelInfo)
    {
        this.data = data;
        if(mySprite != null)
        {
            mySprite.sprite = GameManager.Instance.tower.GetTowerSprite(data.TOWERTYPE, data.TOWERGRADE);
        }

        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => panelInfo.InitInfoPanel(data));
    }
}
