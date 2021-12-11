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

    List<TowerMerge> mergeReadyTowerList = new List<TowerMerge>();
    List<TowerScript> towerPool = new List<TowerScript>();

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

    public List<TowerScript> GetAllLivingTowerData()
    {
        List<TowerScript> result = new List<TowerScript>();
        towerPool.FindAll(x => x.gameObject.activeSelf).ForEach(x => result.Add(x));
        return result;
    }

    public void AddMergeReadyTower(TowerMerge tower)
    {
        mergeReadyTowerList.Add(tower);
        newMergeTower();
    }

    public void MakeAllLoadedTower(List<TowerData> towerDatas)
    {
        Time.timeScale = 0; 
        foreach (var item in towerDatas)
        {
            MakeLoadedTower(item).SetData(item.GetCopiedTowerData());
        }
        Time.timeScale = 1;
    }

    public TowerScript MakeLoadedTower(TowerData data)
    {
        TowerScript result = Instantiate(towerPrefab, this.transform).GetComponent<TowerScript>();
        result.transform.position = data.Position;

        return result;
    }

    public TowerScript GetNewTower(int idx)
    {
        TowerScript result = null;
        if (towerPool.Count >= 1)
        {
            result = towerPool.Find(x => x.TowerData.Idx == idx && !x.gameObject.activeSelf);
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

    private TowerScript MakeNewTower(int idx)
    {
        TowerScript result = Instantiate(towerPrefab, this.transform).GetComponent<TowerScript>();
        return result;
    }

    public TowerScript GetRandTower()
    {
        TowerScript result = GetNewTower(curRandIdx);
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
        originTower.GetComponent<TowerScript>().SetData(GameManager.Instance.towerData.GetTowerDatas()[originTower.GetTowerIdx() + 1]); // 다음 티어의 타워를 가져옴

        originTower.gameObject.SetActive(false);
        originTower.gameObject.SetActive(true);
        // 안에있는 OnEnable과 OnDisable이 작동하도록 함.
    }
}
