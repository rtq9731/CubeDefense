using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float gameSpeed = 1f;
    public bool isHeightOver = false;

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
        FindObjectOfType<TowerSpawner>().gameObject.SetActive(true);
    }

    public void SaveGame()
    {

    }

    public void LoadGame()
    {
        //StageManager의 stageTimer 세팅 해줄것
    }
}
