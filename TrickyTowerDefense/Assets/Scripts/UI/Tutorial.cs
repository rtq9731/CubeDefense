using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialPanels;

    int tutorialLength = 0;

    public void StartTuto()
    {
        Debug.Log("¤¾¤·1");
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

            text.DOText(msg, 3f).SetEase(Ease.Linear);

            num++;
            yield return new WaitForSeconds(4f);
            tutorialPanels[num - 1].gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        GameManager.Instance.StartGame();
        UIStackManager.RemoveUIOnTop();
    }
}
