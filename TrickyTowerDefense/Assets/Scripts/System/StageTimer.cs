using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTimer : MonoBehaviour
{
    PanelInfoTexts info = null;

    private void Start()
    {
        info = FindObjectOfType<PanelInfoTexts>();
    }

    private void Update()
    {
        GameManager.Instance.GetData().Time += Time.deltaTime * GameManager.Instance.gameSpeed;
        info.UpdateOnlyTime();
    }

}
