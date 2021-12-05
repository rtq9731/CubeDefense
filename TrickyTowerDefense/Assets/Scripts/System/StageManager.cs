using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] float stageTime = 60f;
    [SerializeField] float stageWaitTime = 20f;

    StageTimer stageTimer = null;

    private void Awake()
    {
        stageTimer = GetComponent<StageTimer>();
        stageTimer.SetStageTimer(stageTime, stageWaitTime);
    }
}
