using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PanelInfoTexts infoTexts = null;

    private void Start()
    {
        infoTexts = FindObjectOfType<PanelInfoTexts>();
    }
}
