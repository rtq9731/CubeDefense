using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject exitMenu;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UIStackManager.RemoveUIOnTop();

            if(UIStackManager.IsUIStackEmpty())
            {
                exitMenu.transform.parent.gameObject.SetActive(true);
            }
        }
    }
}
