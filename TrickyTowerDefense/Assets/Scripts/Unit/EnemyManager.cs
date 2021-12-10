using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyScript _enemyPrefab = null;
    [SerializeField] BtnSkipStage _btnSkipRound = null;
    [SerializeField] Transform[] _spawnPoints = null;
    [SerializeField] Transform poolParent = null;
    EnemySpawner _enemySpawner = null;

    List<EnemyScript> enemies = new List<EnemyScript>();

    PanelInfoTexts _info = null;

    public List<EnemyScript> Enemies => enemies;

    private void Start()
    {
        _info = FindObjectOfType<PanelInfoTexts>();
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public EnemyScript SpawnEnemy(Vector2 dir, int tier)
    {
        if (tier == -1)
            return null;

        EnemyScript result = enemies.Find(x => !x.gameObject.activeSelf);

        if (result == null)
        {
            result = MakeNewEnemy();
        }
        result.transform.position = dir == Vector2.left ? _spawnPoints[0].position : _spawnPoints[1].position;
        result.SetData(GameManager.Instance.enemyData.GetEnemyData(tier).GetCopiedData(), -dir);
        result.gameObject.SetActive(true);
        result.OnEnmeyDeath += () => _info.UpdateTexts();
        result.OnEnmeyDeath += CheckStageClear;
        return result;
    }

    public void SpawnBoss(int idx)
    {
        
    }

    private void CheckStageClear()
    {
        if (!enemies.Find(x => x.gameObject.activeSelf) && _enemySpawner.isOverSpawn)
        {
            _btnSkipRound.ShowSkipBtn();
        }
    }
    
    private EnemyScript MakeNewEnemy()
    {
        EnemyScript result = Instantiate(_enemyPrefab, poolParent).GetComponent<EnemyScript>();
        enemies.Add(result);
        return result;
    }

}
