using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class HeightChecker : MonoBehaviour
{
    [SerializeField] float gameOverTime = 1f;
    [SerializeField] LayerMask whatIsTower;

    LineRenderer lr = null;
    RaycastHit2D lasthit;
    RaycastHit2D hit;

    List<GameObject> overHeightTowerList = new List<GameObject>();
    float overHeightTimer = 0f;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, new Vector2(-5, transform.position.y));
        lr.SetPosition(1, new Vector2(5, transform.position.y));
    }

    private void Update()
    {
        Debug.DrawRay(lr.GetPosition(0), Vector2.right, Color.green, 100);
        if (hit = Physics2D.Raycast(lr.GetPosition(0), Vector2.right, 100, whatIsTower))
        {
            if (lasthit == hit)
            {
                overHeightTimer += Time.deltaTime;

                if(overHeightTimer >= gameOverTime)
                {
                    GameManager.Instance.isHeightOver = true;
                    gameObject.SetActive(false);
                    // Ÿ�� �ױ� ����
                }
            }
            else
            {
                overHeightTimer = 0f;
                lasthit = hit;
            }
        }
    }

}
