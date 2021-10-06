using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] public Tower tower = null;
    [SerializeField] public TowerParent towerParent = null;

    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }
}
