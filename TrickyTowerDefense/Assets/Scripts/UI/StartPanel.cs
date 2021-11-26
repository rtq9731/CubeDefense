using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    private void Awake()
    {
        UIStackManager.AddUIToStack(this.gameObject);
    }
    private void OnDestroy()
    {
        UIStackManager.RemoveUIOnTop();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RemoveStartPanel();
        }
    }

    public void RemoveStartPanel()
    {
        GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() => { Destroy(gameObject); });
    }
}
