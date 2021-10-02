using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWikiElement : MonoBehaviour
{
    [SerializeField] GameObject myPanel;

    private void Start()
    {
        GetComponent<UnityEngine.UI.Toggle>().onValueChanged.AddListener(isOn =>
        {
            if(myPanel.activeSelf != isOn)
            {
                myPanel.SetActive(isOn);
            }
        });
    }
}
