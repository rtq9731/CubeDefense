using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public void RemoveStartPanel()
    {
        GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() => { gameObject.SetActive(false); });
    }
}
