using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float gameSpeed = 1f;

    [SerializeField] public Tower towerData = null;

    [SerializeField] public EnemyManager enemyManager = null;
    [SerializeField] public TowerManager towerManager = null;

    [SerializeField] public PlayerData data;
    
    public PlayerData GetData()
    {
        return data;
    }

    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }
}
