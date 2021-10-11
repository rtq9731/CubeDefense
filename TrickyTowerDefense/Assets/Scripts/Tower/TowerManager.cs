using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] Transform towerSpawnPoint;

    TowerHeightChecker heightChecker;

    public float leftMin = 0f;
    public float leftLimit = 0f;
    public float rightMin = 0f;
    public float rightLimit = 0f;

    List<TowerScript> towerList = new List<TowerScript>();

    List<TowerScript> mergeReadyTowerList = new List<TowerScript>();

    List<TowerScript> towerPool = new List<TowerScript>();

    public List<TowerScript> GetTowerList()
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

    public void AddMergeReadyTower(TowerScript tower)
    {
        mergeReadyTowerList.Add(tower);
    }

    public TowerScript GetNewTower(int idx)
    {
        TowerScript result = null;
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

    private TowerScript MakeNewTower(int idx)
    {
        TowerScript result = Instantiate(towerPrefab, this.transform).GetComponent<TowerScript>();
        result.SetData(GameManager.Instance.tower.GetTowerDatas()[idx]);
        return result;
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
