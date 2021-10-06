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
        textATK.text = $"���ݷ� : {data.Atk}";
        textPenetration.text = data.Ispenetrate ? "���� ���� : O" : "���� ���� : X";
        textTMI.text = data.TMI;

        switch (data.TOWERTYPE)
        {
            case TowerData.TowerType.Grenadier:
                textAttackSpeed.text = "���ݼӵ� : ����";
                textRange.text = "��Ÿ� : ���߰Ÿ�";
                break;
            case TowerData.TowerType.Laser:
                textAttackSpeed.text = "���ݼӵ� : �ſ� ����";
                textRange.text = "��Ÿ� : ��Ÿ�";
                break;
            case TowerData.TowerType.Acher:
                textAttackSpeed.text = $"���ݼӵ� : ����";
                textRange.text = "��Ÿ� : ��Ÿ�";
                break;
            case TowerData.TowerType.Bullet:
                textAttackSpeed.text = $"���ݼӵ� : ����";
                textRange.text = "��Ÿ� : ���߰Ÿ�";
                break;
            case TowerData.TowerType.Buff:
                textAttackSpeed.text = $"���ݼӵ� : ����";
                textRange.text = "��Ÿ� : �� �� �ΰ�";
                textATK.text = $"���ݷ� {data.Atk}��";
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
