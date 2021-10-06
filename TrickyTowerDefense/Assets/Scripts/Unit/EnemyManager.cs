using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<EnemyScript> allEnemyList = new List<EnemyScript>();
    List<EnemyScript> leftEnemyList = new List<EnemyScript>();
    List<EnemyScript> rightEnemyList = new List<EnemyScript>();

    public EnemyScript GetLeftEnemy()
    {
        return leftEnemyList[0];
    }

    public EnemyScript GetRigthEnemy()
    {
        return rightEnemyList[0];
    }
}
