using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoTexts : MonoBehaviour
{
    public Text textCurRound = null;
    public Text textCurHP = null;
    public Text textCurGold = null;
    public Text textIsOnRound = null;

    private void Start()
    {
        InitTexts(GameManager.Instance.GetData());
    }

    public void InitTexts(PlayerData data)
    {
        textCurRound.text = $"현재 라운드 : {data.Round + 1}";
        textCurHP.text = $"남은 체력 : {data.HP}";
        textCurGold.text = $"현재 골드 : {data.Gold} + {GameManager.Instance.stageManager.PlusGold} (대기)";
        textIsOnRound.text = $"스테이지 준비 시간입니다.";
    }

    public void UpdateTexts()
    {
        PlayerData data = GameManager.Instance.GetData();

        if (data != null)
        {
            textCurRound.text = $"현재 라운드 : {data.Round + 1}";
            textCurHP.text = $"남은 체력 : {data.HP}";
            textCurGold.text = $"현재 골드 : {data.Gold} + {GameManager.Instance.stageManager.PlusGold} (대기)";
        }
    }

    public void UpdateStageTextOnStartStage()
    {
        textIsOnRound.text = $"! 스테이지가 진행 중 입니다 !";
    }

    public void UpdateStageTextOnEndStage()
    {
        textIsOnRound.text = $"스테이지 준비 시간입니다.";
    }
}
