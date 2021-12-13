using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    SpriteRenderer _sr = null;
    EnemyData _data = new EnemyData();
    EnemyHealth _health = null;
    StageManager _stageManager = null;

    public Vector2 _dir = Vector2.zero;

    private Action _onEnemyDeath = () => { };
    public Action OnEnmeyDeath
    {
        get { return _onEnemyDeath; } set { _onEnemyDeath = value; }
    }

    public EnemyData Data
    {
        get { return _data; }
    }

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _dir = transform.position.x >= 0 ? Vector2.left : Vector2.right;
    }

    private void Start()
    {
        _health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {   
        transform.Translate(_dir * Time.deltaTime * GameManager.Instance.gameSpeed * _data.Speed);
    }

    public void SetData(EnemyData data, Vector2 dir)
    {
        _data = data;
        _sr.sprite = Resources.Load<Sprite>(data.Imagepath);
        _dir = dir;
    }

    public void Hit(float damage)
    {
        GameManager.Instance.textEffectManager.GetTextEffect($"-{damage}", Color.red, transform.position, false);
        _health.Hit(damage);
    }
}
