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
        InitTexts(GameManager.Instance.GetData());
    }

    public void InitTexts(PlayerData data)
    {
        textCurRound.text = $"현재 라운드 : {data.Round}";
        textCurHP.text = $"남은 체력 : {data.HP}";
        textCurGold.text = $"현재 골드 : {data.Gold}";
        textRemainSec.text = $"다음 라운드까지 : {data.Time}";
    }

    public void UpdateTexts()
    {
        PlayerData data = GameManager.Instance.GetData();
        textCurRound.text = $"현재 라운드 : {data.Round}";
        textCurHP.text = $"남은 체력 : {data.HP}";
        textCurGold.text = $"현재 골드 : {data.Gold}";
        textRemainSec.text = $"다음 라운드까지 : {data.Time}";
    }

    public void UpdateOnlyTime()
    {
        textRemainSec.text = $"다음 라운드까지 : {GameManager.Instance.GetData().Time.ToString("F2")}";
    }
}
