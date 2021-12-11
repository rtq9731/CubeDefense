using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float gameSpeed = 1f;
    public bool isHeightOver = false;

    string fileExtension = ".sav";
    string filePath = "";

    [SerializeField] public Tower towerData = null;
    [SerializeField] public Enemy enemyData = null;
    [SerializeField] public StageData stageData = null;

    [SerializeField] public EnemyManager enemyManager = null;
    [SerializeField] public TowerManager towerManager = null;
    [SerializeField] public StageManager stageManager = null;
    [SerializeField] public HeightChecker heightChecker = null;
    [SerializeField] public UIManager uiManager = null;

    private PlayerData data = new PlayerData();
    
    public PlayerData GetData()
    {
        return data;
    }

    private void Awake()
    {
        filePath = Application.dataPath;
    }

    private void Start()
    {
        gameSpeed = 0f;
        LoadGame();
    }

    public void StartGame()
    {
        gameSpeed = 1f;

        FindObjectOfType<TowerSpawner>().gameObject.SetActive(true);
    }

    public void SaveGame()
    {
        data.Towers = Instance.towerManager.GetAllLivingTowerData();

        foreach (var item in data.Towers)
        {
            item.TowerData.Position = item.transform.position;
            data.TowerDatas.Add(item.TowerData);
        } 

        using (StreamWriter sw = new StreamWriter(filePath + "/save" + fileExtension))
        {
            sw.Write(JsonUtility.ToJson(data));
        }
    }

    public void LoadGame()
    {
        try
        {
            using (StreamReader sr = new StreamReader(filePath + "/save" + fileExtension))
            {
                data = JsonUtility.FromJson<PlayerData>(sr.ReadToEnd());
            }

            if(data == null)
            {
                data = new PlayerData();
                return;
            }

            towerManager.MakeAllLoadedTower(data.TowerDatas);
            uiManager.infoTexts.UpdateTexts();
            
        }
        catch
        {

        }
    }
}
