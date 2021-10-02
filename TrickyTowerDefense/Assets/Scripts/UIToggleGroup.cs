using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIToggleGroup : MonoBehaviour
{
    [SerializeField] ToggleGroup toggleGroup;
    [SerializeField] List<GameObject> toggleGameObjects;

    List<Toggle> toggles;

    private void Start()
    {
        toggles = toggleGroup.ActiveToggles().ToList();
        ResetToggleGroup();
    }

    private void Update()
    {
        if(toggles.Find(x => x.isOn) != null)
        {

        }
    }

    public void ResetToggleGroup()
    {
        Toggle activeToggle = toggles.Find(x => x.isOn);
        if (activeToggle != null)
        {
            toggles.FindAll(x => x != activeToggle).ForEach(x => x.GetComponent<RectTransform>().DOAnchorPosY(-1, 0.1f));
        }
    }
}
