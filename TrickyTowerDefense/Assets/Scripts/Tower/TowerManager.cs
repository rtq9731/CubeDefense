using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] public Transform towerSpawnPoint;
    [SerializeField] public TowerBuyUI towerBuyUI;

    TowerHeightChecker heightChecker;

    public float leftMin = 0f;
    public float leftLimit = 0f;
    public float rightMin = 0f;
    public float rightLimit = 0f;

    List<TowerMerge> towerList = new List<TowerMerge>();

    List<TowerMerge> mergeReadyTowerList = new List<TowerMerge>();

    List<TowerMerge> towerPool = new List<TowerMerge>();

    public List<TowerMerge> GetTowerList()
    {
        return towerList;
    }

    private void Update()
    {
        if(mergeReadyTowerList.Count >= 2)
        {
            MergeTower(mergeReadyTowerList[0], mergeReadyTowerList[1]);
            mergeReadyTowerList.Clear();
        }
    }

    public void AddMergeReadyTower(TowerMerge tower)
    {
        mergeReadyTowerList.Add(tower);
    }

    public TowerMerge GetNewTower(int idx)
    {
        TowerMerge result = null;
        if (towerPool.Count >= 1)
        {
            result = towerPool.Find(x => !towerList.Contains(x) && x.GetTowerIdx() == idx);
            if(result == null)
            {
                result = MakeNewTower(idx);
                towerPool.Add(result);
            }
        }
        else
        {
            result = MakeNewTower(idx);

            towerPool.Add(result);
        }

        result.transform.position = towerSpawnPoint.position;
        result.gameObject.SetActive(true);

        return result;
    }

    private TowerMerge MakeNewTower(int idx)
    {
        TowerMerge result = Instantiate(towerPrefab, this.transform).GetComponent<TowerMerge>();
        result.SetData(GameManager.Instance.towerData.GetTowerDatas()[idx]);
        return result;
    }

    public void MergeTower(TowerMerge originTower, TowerMerge secondTower)
    {
        secondTower.gameObject.SetActive(false);
        originTower.SetData(GameManager.Instance.towerData.GetTowerDatas()[originTower.GetTowerIdx() + 1]); // 다음 티어의 타워를 가져옴
    }
}
