using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTopCenter : MonoBehaviour
{
    [SerializeField] List<UITopCenterElement> elements = new List<UITopCenterElement>();

    private void Start()
    {
        elements.ForEach(x =>
        {
            if(x.myBtn != null && x.myPanel != null)
            {
                x.myBtn.onClick.AddListener(() => x.myPanel.SetActive(true));
            }
        });
    }
}
