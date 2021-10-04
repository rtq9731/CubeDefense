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

    public int atk = 0;
    public float atkSpeed = 0;

    public TowerData(int atk, float atkSpeed, TowerType type, TowerGrade grade)
    {
        this.myType = type;
        this.myGrade = grade;
        this.atk = atk;
        this.atkSpeed = atkSpeed;
    }
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