using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TowerParent : MonoBehaviour
{
    List<TowerScript> allTowerList = new List<TowerScript>();
    List<TowerScript> leftTowerList = new List<TowerScript>();
    List<TowerScript> rightTowerList = new List<TowerScript>();

    List<TowerScript> mergeReadyTower = new List<TowerScript>();

    private void Update()
    {
        if(mergeReadyTower.Count >= 2)
        {
            MergeTower(mergeReadyTower[0], mergeReadyTower[1]);    
        }
    }

    public void Fire(float atk, Vector2 towerPos, Transform target)
    {

    }

    public void MergeTower(TowerScript originTower, TowerScript secondTower)
    {
        allTowerList.Remove(secondTower);
        leftTowerList.Remove(secondTower);
        rightTowerList.Remove(secondTower);

        originTower.SetData(GameManager.Instance.tower.GetTowerDatas()[originTower.GetTowerIdx() + 1]); // 다음 티어의 타워를 가져옴
    }
}
