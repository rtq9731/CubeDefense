using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuyUI : MonoBehaviour
{
    [SerializeField] Transform towerSpwan = null;
    [SerializeField] Transform leftWall = null;
    [SerializeField] Transform rightWall = null;

    [SerializeField] float speed;
    [SerializeField] LineRenderer lr = null;

    float horizontalAxis = 0f;

    Vector2 movePos = Vector2.zero;

    Button btnBuyTower;
    int towerIdx = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.towerManager.GetNewTower(towerIdx);
            gameObject.SetActive(false);
            towerSpwan.gameObject.SetActive(false);
            btnBuyTower.interactable = true;
            return;
        }

        horizontalAxis = Input.GetAxis("Horizontal");
        if(horizontalAxis != 0)
        {
            movePos = towerSpwan.position;
            movePos.x += speed * Time.deltaTime * horizontalAxis;
            movePos.x = Mathf.Clamp(movePos.x, leftWall.transform.position.x + 0.75f, rightWall.transform.position.x - 0.75f);
            towerSpwan.position = movePos;
        }

        lr.SetPosition(0, towerSpwan.position);
        lr.SetPosition(1, new Vector3(towerSpwan.position.x, -5, towerSpwan.position.z));
    }

    public void initTowerBuyUI(int towerIdx, Button btnBuyTower)
    {
        this.towerIdx = towerIdx;
        this.btnBuyTower = btnBuyTower;
        towerSpwan.gameObject.SetActive(true);
        towerSpwan.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.tower.GetTowerSprite(towerIdx);
        gameObject.SetActive(true);
    }

}
