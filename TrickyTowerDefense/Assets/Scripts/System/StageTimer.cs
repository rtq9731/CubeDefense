using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTimer : MonoBehaviour
{
    private void Update()
    {
        GameManager.Instance.data.Time += Time.deltaTime * GameManager.Instance.gameSpeed;   
    }

}
