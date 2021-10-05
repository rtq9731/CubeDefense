using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerGradeUI : MonoBehaviour
{
    [SerializeField] List<GameObject> gradeStars;
    [SerializeField] Text gradeText = null;
    [SerializeField] Image gradeBarImage = null;

    [SerializeField] List<Color> gradeColorset;

    public void UpdateGradeUI(int grade)
    {
        gradeStars.ForEach(x => x.SetActive(false));

        gradeText.text = ((TowerData.TowerGrade)grade).ToString();
        gradeText.color = gradeColorset[grade];
        gradeBarImage.color = gradeColorset[grade];

        for (int i = 0; i < grade; i++)
        {
            gradeStars[i].SetActive(true);
        }
    }
}
