using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoolTimer : MonoBehaviour
{
    [SerializeField] Button btn = null;
    [SerializeField] float UICoolTime = 0f;

    float timer = 0f;

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            btn.interactable = false;
            timer = Time.time + UICoolTime;
        });
    }

    private void Update()
    {
        if(!btn.interactable)
        {
            if(Time.time >= timer)
            {
                btn.interactable = true;
            }
        }
    }
}
