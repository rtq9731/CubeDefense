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

            buttons[i].onClick.AddListener(() =>
            {
                GameManager.Instance.gameSpeed = timeSpeed;
                MoveArrow(timeSpeed > 1 ? (timeSpeed - 1) * 32 : -32);
            });
        }

        arrowTween = arrowRect.DOAnchorPosY(arrowRect.anchoredPosition.y - 10, 0.3f);
        arrowTween.SetLoops(-1, LoopType.Yoyo);
    }

    public void MoveArrow(float xPos)
    {
        if (arrowTween != null)
        {
            arrowTween.Kill();
        }

        arrowRect.anchoredPosition = new Vector2(xPos, -48);
        arrowTween = arrowRect.DOAnchorPosY(arrowRect.anchoredPosition.y - 10, 0.3f);
        arrowTween.SetLoops(-1, LoopType.Yoyo);
    }
}
