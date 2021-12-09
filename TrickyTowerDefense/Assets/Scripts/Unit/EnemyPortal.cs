using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortal : MonoBehaviour
{
    PanelInfoTexts _info;
    private void Start()
    {
        _info = FindObjectOfType<PanelInfoTexts>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            GameManager.Instance.GetData().HP--;
            _info.UpdateTexts();
        }
    }
}
