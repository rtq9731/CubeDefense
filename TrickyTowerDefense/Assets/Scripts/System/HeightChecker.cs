using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class HeightChecker : MonoBehaviour
{
    [SerializeField] float gameOverTime = 1f;

    LineRenderer lr = null;
    TowerManager towerManager = null;

    List<GameObject> overHeightTowerList = new List<GameObject>();
    float overHeightTimer = 0f;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, new Vector2(-5, transform.position.y));
        lr.SetPosition(1, new Vector2(5, transform.position.y));
    }

    private void Start()
    {
        towerManager = GameManager.Instance.towerManager;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tower"))
        {
            overHeightTowerList.Add(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            if (overHeightTowerList.Count > 0)
            {
                overHeightTimer += Time.deltaTime * GameManager.Instance.gameSpeed;

                if(gameOverTime <= overHeightTimer)
                {
                    GameManager.Instance.isHeightOver = true;
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Tower"))
        {
            if(overHeightTowerList.Contains(collision.gameObject))
            {
                overHeightTowerList.Remove(collision.gameObject);
            }

            if(overHeightTowerList.Count < 1)
            {
                overHeightTimer = 0f;
            }
        }
    }

}
