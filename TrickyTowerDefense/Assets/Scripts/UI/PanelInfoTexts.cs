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
        textCurRound.text = $"���� ���� : {data.Round + 1}";
        textCurHP.text = $"���� ü�� : {data.HP}";
        textCurGold.text = $"���� ��� : {data.Gold} + {GameManager.Instance.stageManager.PlusGold} (���)";
        textIsOnRound.text = $"�������� �غ� �ð��Դϴ�.";
    }

    public void UpdateTexts()
    {
        PlayerData data = GameManager.Instance.GetData();

        if (data != null)
        {
            textCurRound.text = $"���� ���� : {data.Round + 1}";
            textCurHP.text = $"���� ü�� : {data.HP}";
            textCurGold.text = $"���� ��� : {data.Gold} + {GameManager.Instance.stageManager.PlusGold} (���)";
        }
    }

    public void UpdateStageTextOnStartStage()
    {
        textIsOnRound.text = $"! ���������� ���� �� �Դϴ� !";
    }

    public void UpdateStageTextOnEndStage()
    {
        textIsOnRound.text = $"�������� �غ� �ð��Դϴ�.";
    }
}
