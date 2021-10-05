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
        textATK.text = $"���ݷ� {data.atk}";
        textRange.text = $"��Ÿ� : {data.range}";
        textAttackSpeed.text = $"���ݼӵ� : {data.atkSpeed}";
        textPenetration.text = data.isCanPenetrate ? "���� ���� : O" : "���� ���� : X";
    }

    private Sprite GetTowerImage(TowerType towerType, TowerGrade towerGrade)
    {
        return null;
    }
}
