using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHeightChecker : MonoBehaviour
{
    [Header("���� ������Ʈ ���� ���� ����")]
    [SerializeField] float towerHeightPoint = 5f;
    TowerManager towerManager = null;
    CameraMove cameraMove = null;

    public float highestHeight = 0f;

    private void Start()
    {
        cameraMove = FindObjectOfType<CameraMove>();
        towerManager = GameManager.Instance.towerManager;
    }

    public void TowerHeightCheck(TowerScript tower)
    {
        if(tower.transform.position.y > highestHeight)
        {
            highestHeight += towerHeightPoint;
            towerManager.towerSpawnPoint.position = new Vector3(towerManager.towerSpawnPoint.position.x, highestHeight + towerHeightPoint + 2);
        }
    }
}
