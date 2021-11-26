using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    float stageTimer = 0f;

    void Update()
    {
        stageTimer += Time.deltaTime * GameManager.Instance.gameSpeed;        
    }
}
