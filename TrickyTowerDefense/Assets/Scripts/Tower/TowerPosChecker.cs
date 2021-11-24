using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPosChecker : MonoBehaviour
{
    public System.Action<GameObject> towerPosChangedAct = null;

    TowerScript tower = null;
    private void Awake()
    {
        tower = GetComponent<TowerScript>();
    }                   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            tower.TowerData.Position = transform.position;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            tower.TowerData.Position = transform.position;
        }
    }
}
