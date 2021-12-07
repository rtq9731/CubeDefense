using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] float stageTime = 100f;
    [SerializeField] float stageWaitTime = 20f;
    public int plusGold = 0; // 라운드 끝날때까지 기다린다음 골드 지급

    StageTimer stageTimer = null;

    private void Awake()
    {
        stageTimer = GetComponent<StageTimer>();
        stageTimer.SetStageTimer(stageTime, stageWaitTime);
        stageTimer._onStageStart += () => { GameManager.Instance.GetData().Gold += plusGold; };
    }
}
