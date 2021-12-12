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
                MoveArrow(buttons[y].transform.position);
            });
        }

        arrowRect.anchoredPosition = new Vector2(buttons[0].transform.position.x - 24, buttons[0].transform.position.y - 72); // 8 32
        arrowTween = arrowRect.DOAnchorPosY(arrowRect.anchoredPosition.y - 10, 0.3f);
        arrowTween.SetLoops(-1, LoopType.Yoyo);
    }

    public void MoveArrow(Vector2 Pos)
    {
        if (arrowTween != null)
        {
            arrowTween.Kill();
        }

        arrowRect.anchoredPosition = new Vector2(Pos.x -24, Pos.y - 72); // 8 32
        arrowTween = arrowRect.DOAnchorPosY(arrowRect.anchoredPosition.y - 10, 0.3f);
        arrowTween.SetLoops(-1, LoopType.Yoyo);
    }
}
