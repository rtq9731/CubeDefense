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
        textATK.text = $"���ݷ� {data.Atk}";
        textRange.text = $"��Ÿ� : {data.Range}";
        textAttackSpeed.text = $"���ݼӵ� : {data.Atkspeed}";
        textPenetration.text = data.Ispenetrate ? "���� ���� : O" : "���� ���� : X";
    }

    private Sprite GetTowerImage(TowerData.TowerType towerType, TowerData.TowerGrade towerGrade)
    {
        return null;
    }
}
