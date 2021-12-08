using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyScript enemyPrefab = null;

    [SerializeField] Transform[] spawnPoints = null;

    List<EnemyScript> enemies = new List<EnemyScript>();

    public List<EnemyScript> Enemies => enemies;

    public EnemyScript SpawnEnemy(Vector2 dir, int tier)
    {
        if (tier == -1)
            return null;

        EnemyScript result = enemies.Find(x => !x.gameObject.activeSelf);

        if (result == null)
        {
            result = MakeNewEnemy();
        }
        result.transform.position = dir == Vector2.left ? spawnPoints[0].position : spawnPoints[1].position;
        result.SetData(GameManager.Instance.enemyData.GetEnemyData(tier).GetCopiedData(), -dir);
        result.gameObject.SetActive(true);

        return result;
    }

    public void SpawnBoss(int idx)
    {
        
    }

    private EnemyScript MakeNewEnemy()
    {
        EnemyScript result = Instantiate(enemyPrefab, this.transform).GetComponent<EnemyScript>();
        enemies.Add(result);
        return result;
    }

}
