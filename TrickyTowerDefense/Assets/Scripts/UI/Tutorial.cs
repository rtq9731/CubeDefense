using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialPanels;

    Tween t;
    int tutorialLength = 0;

    public void StartTuto()
    {
        gameObject.SetActive(true);
        tutorialLength = tutorialPanels.Length;
        int num = 0;
        FindObjectOfType<StartPanel>().gameObject.SetActive(false);
        StartCoroutine(tutorial(num));
    }

    private IEnumerator tutorial(int num)
    {
        while(num + 1 < tutorialLength)
        {
            tutorialPanels[num].SetActive(true);
            Text text = tutorialPanels[num].GetComponentInChildren<Text>();
            string msg = text.text;
            text.text = "";
            
            t = text.DOText(msg, msg.Length * 0.1f).SetEase(Ease.Linear);

            num++;

            yield return new WaitForSeconds(msg.Length * 0.1f + msg.Length * 0.15f);
            tutorialPanels[num - 1].gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        GameManager.Instance.StartGame();
        UIStackManager.RemoveUIOnTop();
    }
}
