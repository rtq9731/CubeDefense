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

    [SerializeField] public EnemyManager enemyManager = null;
    [SerializeField] public TowerManager towerManager = null;
    [SerializeField] public HeightChecker heightChecker = null;

    [SerializeField] PlayerData data;
    
    public PlayerData GetData()
    {
        return data;
    }

    private void Start()
    {
        gameSpeed = 0f;
    }

    public void StartGame()
    {
        gameSpeed = 1f;

        LoadGame(() => {
            FindObjectOfType<StageManager>().CheckStage(); 
        });

        FindObjectOfType<TowerSpawner>().gameObject.SetActive(true);
    }

    public void SaveGame()
    {
        data.Round = FindObjectOfType<StageManager>().CheckStage();
        using (StreamWriter sw = new StreamWriter(filePath + "/save" + fileExtension))
        {
            sw.Write(JsonUtility.ToJson(data));
        }
    }

    public void LoadGame(Action loadCallback)
    {
        using (StreamReader sr = new StreamReader(filePath + "/save" + fileExtension))
        {
            data = JsonUtility.FromJson<PlayerData>(sr.ReadToEnd());
        }

        loadCallback();
        //StageManager의 stageTimer 세팅 해줄것
    }
}
