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
        textATK.text = $"공격력 : {data.Atk}";
        textPenetration.text = data.Ispenetrate ? "관통 여부 : O" : "관통 여부 : X";
        textTMI.text = data.TMI;

        switch (data.TOWERTYPE)
        {
            case TowerData.TowerType.Grenadier:
                textAttackSpeed.text = "공격속도 : 느림";
                textRange.text = "사거리 : 근중거리";
                break;
            case TowerData.TowerType.Laser:
                textAttackSpeed.text = "공격속도 : 매우 느림";
                textRange.text = "사거리 : 장거리";
                break;
            case TowerData.TowerType.Acher:
                textAttackSpeed.text = $"공격속도 : 느림";
                textRange.text = "사거리 : 장거리";
                break;
            case TowerData.TowerType.Bullet:
                textAttackSpeed.text = $"공격속도 : 빠름";
                textRange.text = "사거리 : 근중거리";
                break;
            case TowerData.TowerType.Buff:
                textAttackSpeed.text = $"공격속도 : 없음";
                textRange.text = "사거리 : 양 옆 두개";
                textATK.text = $"공격력 {data.Atk}배";
                break;
            default:
                break;
        }

        this.gameObject.SetActive(true);
    }

    private Sprite GetTowerImage(TowerData.TowerType towerType, TowerData.TowerGrade towerGrade)
    {
        return null;
    }
}
