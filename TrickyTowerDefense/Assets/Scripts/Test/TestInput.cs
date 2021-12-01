using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    [SerializeField] GameObject obj = null;

    private void Start()
    {
        GameManager.Instance.gameSpeed = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TowerAttack_Laser attack = FindObjectOfType<TowerAttack_Laser>();
            attack.Attack(0, Instantiate(obj, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity).transform);
        }
    }
}
