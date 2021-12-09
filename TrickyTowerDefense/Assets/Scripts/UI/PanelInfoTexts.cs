using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoTexts : MonoBehaviour
{
    [SerializeField] Text textCurRound = null;
    [SerializeField] Text textCurHP = null;
    [SerializeField] Text textCurGold = null;
    [SerializeField] Text textIsOnRound = null;

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
        textCurRound.text = $"현재 라운드 : {data.Round + 1}";
        textCurHP.text = $"남은 체력 : {data.HP}";
        textCurGold.text = $"현재 골드 : {data.Gold} + {GameManager.Instance.stageManager.PlusGold} (대기)";
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
