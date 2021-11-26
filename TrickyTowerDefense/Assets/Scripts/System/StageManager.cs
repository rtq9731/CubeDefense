using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] float stageTime = 60f;
    [SerializeField] float stageWaitTime = 10f;

    float stageTimer = 0f;

    private void Start()
    {
        float originStageTimer = stageTimer;
        while(stageTimer > 0)
        {
            stage ++;
            stageTimer -= (stageTime + stageWaitTime);
        }
        stageTimer = originStageTimer;
    }

    void Update()
    {
        stageTimer += Time.deltaTime * GameManager.Instance.gameSpeed;        
    }
}
