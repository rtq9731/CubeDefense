using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    System.Action newMergeTower = () => { };

    public float leftMin = 0f;
    public float leftLimit = 0f;
    public float rightMin = 0f;
    public float rightLimit = 0f;

    private int curRandIdx = -1;
    private int nextRandIdx = 0;

    List<TowerMerge> towerList = new List<TowerMerge>();
    List<TowerMerge> mergeReadyTowerList = new List<TowerMerge>();
    List<TowerMerge> towerPool = new List<TowerMerge>();

    private void Start()
    {
        UpdateRandIdx();
        FindObjectOfType<TowerSpawner>().UpdateTowerImage();
        newMergeTower += () =>
        {
            if (mergeReadyTowerList.Count >= 2)
            {
                MergeTower(mergeReadyTowerList[0], mergeReadyTowerList[1]);
                mergeReadyTowerList.Clear();
            }
        };
    }

    public List<TowerMerge> GetTowerList()
    {
        return towerList;
    }

    public List<TowerData> GetAllLivingTowerData()
    {
        List<TowerData> result = new List<TowerData>();
        towerList.FindAll(x => x.gameObject.activeSelf).ForEach(x => result.Add(x.GetComponent<TowerScript>().TowerData));
        return result;
    }

    public void AddMergeReadyTower(TowerMerge tower)
    {
        mergeReadyTowerList.Add(tower);
        newMergeTower();
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

        result.SetData(GameManager.Instance.towerData.GetTowerDatas()[idx].GetCopiedTowerData());
        result.gameObject.SetActive(true);

        return result;
    }

    private TowerMerge MakeNewTower(int idx)
    {
        TowerMerge result = Instantiate(towerPrefab, this.transform).GetComponent<TowerMerge>();
        result.SetData(GameManager.Instance.towerData.GetTowerDatas()[idx]);
        return result;
    }

    public TowerMerge GetRandTower()
    {
        TowerMerge result = GetNewTower(curRandIdx);
        UpdateRandIdx();
        return result;
    }

    public Sprite GetNextRandSprite()
    {
        return GameManager.Instance.towerData.GetTowerSprite(curRandIdx);
    }

    private void UpdateRandIdx()
    {
        List<TowerData> towerDatas = GameManager.Instance.towerData.FindAllTower(TowerData.TowerGrade.Common);
        curRandIdx = nextRandIdx;
        nextRandIdx = towerDatas[Random.Range(0, towerDatas.Count)].Idx;
    }

    public void MergeTower(TowerMerge originTower, TowerMerge secondTower)
    {
        secondTower.gameObject.SetActive(false);
        originTower.SetData(GameManager.Instance.towerData.GetTowerDatas()[originTower.GetTowerIdx() + 1]); // 다음 티어의 타워를 가져옴

        originTower.gameObject.SetActive(false);
        originTower.gameObject.SetActive(true);
        // 안에있는 OnEnable과 OnDisable이 작동하도록 함.
    }
}
