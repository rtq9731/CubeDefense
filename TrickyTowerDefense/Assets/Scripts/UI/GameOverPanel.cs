using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Text gameOverMsg = null;
    [SerializeField] Text gameOverInfo = null;
    [SerializeField] Button[] buttons = null;

    private void Awake()
    {
        buttons[0].onClick.AddListener(() =>
        {
            GameManager.Instance.NewGame();
            gameObject.SetActive(false);
        });
        buttons[1].onClick.AddListener(Application.Quit);
    }

    private void OnEnable()
    {
        string msg = gameOverMsg.text;

        Sequence seq = DOTween.Sequence();
        gameOverMsg.text = "";
        seq.Append(gameOverMsg.DOText(msg, 3f));
        seq.Append(gameOverMsg.DOText($"에러를 막았던 라운드 : {GameManager.Instance.GetData().Round} 라운드", 2f));
    }
}
