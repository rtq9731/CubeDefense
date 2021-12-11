using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextEffectManager : MonoBehaviour
{
    [SerializeField] Text textPrefab = null;
    List<Text> textPool = new List<Text>();
    Camera camera = null;

    private void Start()
    {
        camera = Camera.main;
    }

    public Text GetTextEffect(string msg, Color textColor, Vector3 position, bool isAnchoredPos, int fontSize = 24, Ease easingMode = Ease.InBack, float fadeTime = 0.5f, float moveTime = 0.5f)
    {
        Text result = textPool.Find(x => !x.gameObject.activeSelf);
        if(!isAnchoredPos)
        {
            position = camera.WorldToScreenPoint(position);
        }

        if(result == null)
        {
            result = MakeNewText();
        }

        result.rectTransform.anchoredPosition = position;
        result.text = msg;
        result.color = textColor;
        result.fontSize = fontSize;

        result.rectTransform.DOAnchorPosY(position.y += 100, moveTime).SetEase(easingMode);
        result.DOFade(0, fadeTime);

        return result;
    }

    public Text MakeNewText()
    {
        return Instantiate<Text>(textPrefab, transform);
    }
}
