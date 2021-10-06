using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    List<TowerScript> allTowerList = new List<TowerScript>();
    List<TowerScript> leftTowerList = new List<TowerScript>();
    List<TowerScript> rightTowerList = new List<TowerScript>();

    List<TowerScript> mergeReadyTowerList = new List<TowerScript>();

    Queue<TowerScript> towerPool = new Queue<TowerScript>();

    public List<TowerScript>[] GetTowerList()
    {
        return new List<TowerScript>[] { leftTowerList, allTowerList, rightTowerList };
    }

    private void Update()
    {
        if(mergeReadyTowerList.Count >= 2)
        {
            MergeTower(mergeReadyTowerList[0], mergeReadyTowerList[1]);
            mergeReadyTowerList.Clear();
        }
    }   

    public void AddMergeReadyTower(TowerScript tower)
    {
        mergeReadyTowerList.Add(tower);
    }

    public void GetNewTower(TowerData.TowerType type, TowerData.TowerGrade grade)
    {
        if(towerPool != null)
        {

        }
        else
        {

        }
    }

    private void MakeNewTower(TowerData.TowerType type, TowerData.TowerGrade grade)
    {
        
    }

    public void Fire(float atk, Vector2 towerPos, Transform target)
    {

    }

    public void MergeTower(TowerScript originTower, TowerScript secondTower)
    {
        secondTower.gameObject.SetActive(false);
        originTower.SetData(GameManager.Instance.tower.GetTowerDatas()[originTower.GetTowerIdx() + 1]); // 다음 티어의 타워를 가져옴
    }
}
