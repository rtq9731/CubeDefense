using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class MenuOpen : MonoBehaviour
{
    /// --------------경고--------------------
    /// 미리 수납되어 있는 UI에 적용 될 수 있는 스크립트 입니다.
    /// --------------경고--------------------

    [SerializeField] float moveTime = 0.5f;
    [SerializeField] Direction direction;
    [SerializeField] Toggle menuToggle = null;

    [Header("Toggles on Menu")]
    [SerializeField] Toggle[] toggles;

    RectTransform rect = null;
    Vector2 originPos = Vector2.zero;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        originPos = rect.anchoredPosition;

        switch (direction)
        {
            case Direction.right:
                menuToggle.onValueChanged.AddListener(x => OnValueChangedToggleRight(x));
                break;
            case Direction.left:
                menuToggle.onValueChanged.AddListener(x => OnValueChangedToggleLeft(x));
                break;
            case Direction.up:
                menuToggle.onValueChanged.AddListener(x => OnValueChangedToggleUp(x));
                break;
            case Direction.down:
                menuToggle.onValueChanged.AddListener(x => OnValueChangedToggleDown(x));
                break;
            default:
                break;
        }
    }

    private void OnValueChangedToggleRight(bool isOn)
    {
        if(isOn)
        {
            rect.DOAnchorPosX(0, moveTime);
        }
        else
        {
            rect.DOAnchorPosX(originPos.x, moveTime);

            foreach (var item in toggles)
            {
                item.isOn = false;
            }
        }
    }
    private void OnValueChangedToggleLeft(bool isOn)
    {
        if (isOn)
        {
            rect.DOAnchorPosX(0, moveTime);
        }
        else
        {
            rect.DOAnchorPosX(originPos.x, moveTime);

            foreach (var item in toggles)
            {
                item.isOn = false;
            }
        }
    }
    private void OnValueChangedToggleUp(bool isOn)
    {
        if (isOn)
        {
            rect.DOAnchorPosY(0, moveTime);
        }
        else
        {
            rect.DOAnchorPosY(originPos.x, moveTime);

            foreach (var item in toggles)
            {
                item.isOn = false;
            }
        }
    }
    private void OnValueChangedToggleDown(bool isOn)
    {
        if (isOn)
        {
            rect.DOAnchorPosY(0, moveTime);
        }
        else
        {
            rect.DOAnchorPosY(originPos.x, moveTime);

            foreach (var item in toggles)
            {
                item.isOn = false;
            }
        }
    }


    public enum Direction
    {
        right,
        left,
        up,
        down
    }
}
