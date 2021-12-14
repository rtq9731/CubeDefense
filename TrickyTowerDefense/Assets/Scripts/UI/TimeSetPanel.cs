using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimeSetPanel : MonoBehaviour
{
    [SerializeField] Button[] buttons = null;
    [SerializeField] RectTransform arrowRect = null;

    Tween arrowTween = null;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int timeSpeed = i + 1;
            int y = i;

            buttons[i].onClick.AddListener(() =>
            {
                GameManager.Instance.gameSpeed = timeSpeed;
                MoveArrow(y);
            });
        }

        arrowRect.SetParent(buttons[0].transform.Find("ArrowPos").transform);
        arrowTween = arrowRect.DOAnchorPosY(arrowRect.anchoredPosition.y - 10, 0.3f);
        arrowTween.SetLoops(-1, LoopType.Yoyo);
    }

    public void MoveArrow(int buttonNum)
    {
        if (arrowTween != null)
        {
            arrowTween.Kill();
        }

        arrowRect.SetParent(buttons[buttonNum].transform.Find("ArrowPos").transform);
        arrowRect.anchoredPosition = Vector3.zero;
        arrowTween = arrowRect.DOAnchorPosY(arrowRect.anchoredPosition.y - 10, 0.3f);
        arrowTween.SetLoops(-1, LoopType.Yoyo);
    }
}
