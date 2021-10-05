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
        Sprite towerSprite = GetTowerImage(data.myType, data.myGrade);
        if (towerSprite != null)
        {
            towerImage.sprite = towerSprite;
        }

        textTowerName.text = data.towerName;
        towerGradeUI.UpdateGradeUI((int)data.myGrade);
        textATK.text = $"공격력 {data.atk}";
        textRange.text = $"사거리 : {data.range}";
        textAttackSpeed.text = $"공격속도 : {data.atkSpeed}";
        textPenetration.text = data.isCanPenetrate ? "관통 여부 : O" : "관통 여부 : X";
    }

    private Sprite GetTowerImage(TowerType towerType, TowerGrade towerGrade)
    {
        return null;
    }
}
