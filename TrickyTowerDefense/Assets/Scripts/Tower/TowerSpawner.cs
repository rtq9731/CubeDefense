using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] wallObjs = null;
    [SerializeField] int towerPrice = 0;

    [Header("안전범위")]
    [SerializeField] float safePlus = 0f;

    Vector2 minClampPos = Vector2.zero;
    Vector2 maxClampPos = Vector2.zero;

    bool canBuyNewTower = true;

    TowerManager towerManager = null;

    SpriteRenderer sr = null;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        minClampPos = new Vector2(wallObjs[0].transform.position.x + safePlus, 0);
        maxClampPos = new Vector2(wallObjs[1].transform.position.x - safePlus, 0);
    }

    private void Start()
    {
        towerManager = FindObjectOfType<TowerManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.Instance.isHeightOver || !UIStackManager.IsUIStackEmpty() || !GameManager.Instance.canSpawnTower)
            {
                return;
            }


            Vector3 mousePosOnGame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (IsMouseInSpawnZone(mousePosOnGame) && canBuyNewTower)
            {
                if (GameManager.Instance.GetData().Buy(towerPrice))
                {
                    canBuyNewTower = false;
                    GameObject newTower = towerManager.GetRandTower().gameObject;
                    MoveNewTile(newTower.transform, mousePosOnGame.x);
                }
            }
        }
    }
    
    private bool IsMouseInSpawnZone(Vector3 mousePos)
    {
        return mousePos.x <= maxClampPos.x && mousePos.x >= minClampPos.x;
    }

    private void MoveNewTile(Transform towerTr, float mouseXPos)
    {
        Rigidbody2D rigid2D = towerTr.GetComponent<Rigidbody2D>();

        transform.localScale = Vector3.zero;
        rigid2D.gravityScale = 0;
        rigid2D.velocity = Vector2.zero;
        towerTr.position = this.transform.position;

        towerTr.DOMoveX(mouseXPos, 0.5f).
                OnComplete(() =>
                {
                    rigid2D.gravityScale = 1;
                    rigid2D.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
                });

        UpdateTowerImage();
        transform.DOScale(Vector3.one, 2f).OnComplete(() => canBuyNewTower = true);
    }

    public void UpdateTowerImage()
    {
        sr.sprite = towerManager.GetNextRandSprite();
    }
}
