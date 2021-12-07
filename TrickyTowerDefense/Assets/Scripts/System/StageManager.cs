using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] float stageTime = 100f;
    [SerializeField] float stageWaitTime = 20f;
    public int plusGold = 0; // ���� ���������� ��ٸ����� ��� ����

    StageTimer stageTimer = null;

    private void Awake()
    {
        stageTimer = GetComponent<StageTimer>();
        stageTimer.SetStageTimer(stageTime, stageWaitTime);
        stageTimer._onStageStart += () => { GameManager.Instance.GetData().Gold += plusGold; };
    }
}
