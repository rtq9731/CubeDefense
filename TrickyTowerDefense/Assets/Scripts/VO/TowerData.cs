using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TowerData
{
    public TowerType myType = 0;
    public TowerGrade myGrade = 0;

    public Vector2 position = Vector2.zero;

    public int atk;
    public int atkSpeed;
}

public enum TowerType
{
    Grenadier,
    Laser,
    Acher,
    Bullet,
    Buff
}

public enum TowerGrade
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Unique,
    Legendary
}