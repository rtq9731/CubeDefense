using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _enemySpawnTime = 60f;
    [SerializeField] float _enemySpawnTerm = 1f;

    StageTimer _stageTimer = null;
    EnemyManager _enemyManager = null;

    WaitForSeconds ws = null;

    StageDataData _curStageData = new StageDataData();
    int _curEnemyCount = 0;
    Vector2 _spawnDir = Vector2.right;

    private void Awake()
    {
        ws = new WaitForSeconds(_enemySpawnTerm);
        _stageTimer = GetComponent<StageTimer>();
        _enemyManager = GetComponent<EnemyManager>();
        _stageTimer._onStageStart += SpawnEnemies;
    }

    public void SpawnEnemies()
    {
        int stage = GameManager.Instance.GetData().Round;

        GameManager.Instance.stageData.dataArray[stage].Copy(out _curStageData);
        _curEnemyCount = _curStageData.EnemyCount();
        StartCoroutine(SpawnEnemiesOnTime());
    }

    IEnumerator SpawnEnemiesOnTime()
    {
        while (_curStageData.EnemyCount() > 0)
        {
            _enemyManager.SpawnEnemy(_spawnDir ,_curStageData.GetLastestEnemeyTier());
            _spawnDir *= -1;
            yield return ws;
        }
    }
}
