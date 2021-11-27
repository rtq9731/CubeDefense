using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] float stageTime = 60f;
    [SerializeField] float stageWaitTime = 20f;

    StageTimer stageTimer = null;

    public bool IsInStage
    {
        get { return GameManager.Instance.GetData().Time % (stageTime + stageWaitTime) >= 20; }
    }

    private void Awake()
    {
        GetComponent<StageTimer>();
    }

    public int CheckStageOnLoad()
    {
        float nowTime = GameManager.Instance.GetData().Time;

        stage = (int)(nowTime / (stageTime + stageWaitTime));
        return stage;
    }

    public int CheckStage()
    {
        float stageTimer = GameManager.Instance.GetData().Time;
        float originStageTimer = stageTimer;

        stage = 0;
        while (stageTimer > 0)
        {
            stage++;
            stageTimer -= (stageTime + stageWaitTime);
        }

        GameManager.Instance.GetData().Round = stage;
        return stage;
    }
}
