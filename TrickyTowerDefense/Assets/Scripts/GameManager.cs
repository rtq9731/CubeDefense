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
    [SerializeField] public StageManager stageManaer = null;
    [SerializeField] public HeightChecker heightChecker = null;

    [SerializeField] PlayerData data = new PlayerData();
    
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
        LoadGame();
        gameSpeed = 0f;
    }

    public void StartGame()
    {
        gameSpeed = 1f;

        FindObjectOfType<TowerSpawner>().gameObject.SetActive(true);
    }

    public void SaveGame()
    {
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
            TowerManager towerManager = FindObjectOfType<TowerManager>();
            data.TowerDatas.ForEach(x => towerManager.GetNewTower(x.Idx).transform.position = x.Position);
        }
        catch
        {

        }
    }
}
