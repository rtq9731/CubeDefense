using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float gameSpeed = 1f;
    public bool isHeightOver = false;
    public bool canSpawnTower = true;  

    string fileExtension = ".sav";
    string filePath = "";

    public Tower towerData = null;
    public Enemy enemyData = null;
    public StageData stageData = null;

    public EnemyManager enemyManager = null;
    public TowerManager towerManager = null;
    public StageManager stageManager = null;
    public HeightChecker heightChecker = null;
    public UIManager uiManager = null;
    public TextEffectManager textEffectManager = null;
    public GameOverPanel gameOverPanel = null;

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

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        gameSpeed = 0;
    }

    public void NewGame()
    {
        gameSpeed = 1f;
        data = new PlayerData();
        isHeightOver = false;
        canSpawnTower = true;
        towerManager.ResetALLTowers();
        enemyManager.ResetAllEnemies();
        stageManager.PlusGold = 0;
        uiManager.infoTexts.UpdateTexts();
        SaveGame();
    }

    public void SaveGame()
    {
        data.Towers = towerManager.GetAllLivingTowerData();

        data.TowerDatas = new List<TowerData>();
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
