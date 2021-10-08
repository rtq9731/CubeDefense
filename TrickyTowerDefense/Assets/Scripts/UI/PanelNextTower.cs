using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelNextTower : MonoBehaviour
{
    [SerializeField] Image towerImage = null;

    public void SetNewTowerImage(int towerIdx)
    {
        towerImage.sprite = GameManager.Instance.tower.GetTowerSprite(towerIdx);
    }
}
