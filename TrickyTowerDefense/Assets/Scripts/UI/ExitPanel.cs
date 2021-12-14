using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanel : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    private void Start()
    {
        buttons[0].onClick.AddListener(() => UIStackManager.RemoveUIOnTop());
        buttons[1].onClick.AddListener(Application.Quit);
    }

    private void OnEnable()
    {
        GameManager.Instance.gameSpeed = 0;
    }

    private void OnDisable()
    {
        GameManager.Instance.gameSpeed = 1;    
    }
}
