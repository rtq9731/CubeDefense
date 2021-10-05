using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfo : MonoBehaviour
{
    [SerializeField] Image towerImage = null;
    [SerializeField] Text textTowerName = null;
    [SerializeField] TowerGradeUI towerGradeUI = null;
    [SerializeField] Text textATK = null;
    [SerializeField] Text textRange = null;
    [SerializeField] Text textAttackSpeed = null;
    [SerializeField] Text textPenetration = null;
    [SerializeField] Text textTMI = null;

    public void InitInfoPanel(TowerData data)
    {
        Sprite towerSprite = GetTowerImage(data.TOWERTYPE, data.TOWERGRADE);
        if (towerSprite != null)
        {
            towerImage.sprite = towerSprite;
        }

        textTowerName.text = data.Towername;
        towerGradeUI.UpdateGradeUI((int)data.TOWERGRADE);
        textATK.text = $"공격력 {data.Atk}";
        textRange.text = $"사거리 : {data.Range}";
        textAttackSpeed.text = $"공격속도 : {data.Atkspeed}";
        textPenetration.text = data.Ispenetrate ? "관통 여부 : O" : "관통 여부 : X";
    }

    private Sprite GetTowerImage(TowerData.TowerType towerType, TowerData.TowerGrade towerGrade)
    {
        return null;
    }
}
