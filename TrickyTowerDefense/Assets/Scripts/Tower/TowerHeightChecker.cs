using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHeightChecker : MonoBehaviour
{
    [Header("���� ������Ʈ ���� ���� ����")]
    [SerializeField] float towerHeightPoint;
    TowerManager towerManager = null;
    CameraMove cameraMove = null;

    public float highestHeight = 0f;

    private void Start()
    {
        cameraMove = FindObjectOfType<CameraMove>();
        towerManager = GameManager.Instance.towerManager;
    }

    public void TowerHightCheck()
    {
        if (towerManager.GetTowerList().FindAll(x => x.isTowerPosChanged).Find(x => x.transform.position.y > highestHeight) != null)
        {
            highestHeight += towerHeightPoint;
            cameraMove.yPositionLimit = 7 + highestHeight;
        }
    }
}
