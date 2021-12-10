using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BtnSkipBreak : MonoBehaviour
{
    StageTimer _stageTimer;
    RectTransform _rect;
    Vector3 _originPos = Vector3.zero;
    private void Awake()
    {
        _stageTimer = FindObjectOfType<StageTimer>();
        _rect = GetComponent<RectTransform>();
        _originPos = _rect.anchoredPosition;
    }
    public void ShowSkipBtn()
    {
        _rect.DOAnchorPosY(-_rect.anchoredPosition.y, 0.25f).OnComplete(() =>
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                _stageTimer.SkipBreak();
                RemoveSkipBtn();
            });
        });
    }

    public void RemoveSkipBtn()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        _rect.DOAnchorPosY(_originPos.y, 0.25f);
    }
}
