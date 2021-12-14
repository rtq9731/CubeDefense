using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortal : MonoBehaviour
{
    PanelInfoTexts _info;
    private void Start()
    {
        _info = GameManager.Instance.uiManager.infoTexts;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            GameManager.Instance.GetData().HP -= collision.GetComponent<EnemyScript>().Data.Tier;
            _info.UpdateTexts();
        }
    }
}
