using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _enemySpawnTime = 60f;
    [SerializeField] float _enemySpawnTerm = 1f;

    StageTimer _stageTimer = null;
    EnemyManager _enemyManager = null;

    StageDataData _curStageData = new StageDataData();
    Vector2 _spawnDir = Vector2.right;

    public bool isOverSpawn = false;
    private void Awake()
    {
        _stageTimer = GetComponent<StageTimer>();
        _enemyManager = GetComponent<EnemyManager>();
        _stageTimer._onStageStart += SpawnEnemies;
    }

    public void SpawnEnemies()
    {
        int stage = GameManager.Instance.GetData().Round;

        GameManager.Instance.stageData.dataArray[stage].Copy(out _curStageData);
        isOverSpawn = false;
        StartCoroutine(SpawnEnemiesOnTime());
    }

    IEnumerator SpawnEnemiesOnTime()
    {
        while (_curStageData.EnemyCount() > 0)
        {
            _enemyManager.SpawnEnemy(_spawnDir ,_curStageData.GetLastestEnemeyTier());
            _spawnDir *= -1;
            yield return new WaitForSeconds(_enemySpawnTerm / GameManager.Instance.gameSpeed);
        }
        isOverSpawn = true;
    }
}
