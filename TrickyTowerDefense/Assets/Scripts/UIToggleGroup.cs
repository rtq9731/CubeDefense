using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIToggleGroup : MonoBehaviour
{
    [SerializeField] List<Toggle> toggles = new List<Toggle>();

    Dictionary<Toggle, Vector3> toggleOriginPosDictionary = new Dictionary<Toggle, Vector3>();

    private void Start()
    {
        toggles.ForEach(x => toggleOriginPosDictionary.Add(x, x.GetComponent<RectTransform>().anchoredPosition));

        toggles.ForEach(x => x.onValueChanged.AddListener(isOn =>
        {

            RectTransform myRect = x.transform.GetComponent<RectTransform>();
            myRect.DOComplete();

            if (isOn)
            {
                myRect.DOAnchorPosY(myRect.anchoredPosition.y - 25, 0.1f);
                toggles.FindAll(item => x != item).ForEach(item => item.isOn = false);
            }
            else
            {
                if (toggleOriginPosDictionary.TryGetValue(x, out var originPos))
                {
                    myRect.DOAnchorPos(originPos, 0.1f);
                }
                else
                {
#if UNITY_EDITOR
                    Debug.Log($"{x.name}의 원래 위치를 찾는데 실패했습니다!\n에러로 UI가 움직이지 않을 수 있습니다.");
#endif
                    return;
                }
            }
        }));
    }
}
