using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoTexts : MonoBehaviour
{
    [SerializeField] Text textCurRound = null;
    [SerializeField] Text textCurHP = null;
    [SerializeField] Text textCurGold = null;
    [SerializeField] Text textRemainSec = null;

    private void Start()
    {
        InitTexts(GameManager.Instance.data);
    }

    public void InitTexts(PlayerData data)
    {
        textCurRound.text = $"���� ���� : {data.Round}";
        textCurHP.text = $"���� ü�� : {data.HP}";
        textCurGold.text = $"���� ��� : {data.Gold}";
        textRemainSec.text = $"�ٸ� ������� : {data.Time}";
    }
}
