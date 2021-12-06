using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Coroutine co = null;

    public void Fire(EnemyScript target, float damage)
    {
        co = StartCoroutine(GotoTarget(target, () => { gameObject.SetActive(false); }, damage));
        target.OnEnmeyDeath += RemoveBullet; // 어차피 켜질 때 초기화 해줘서 상관 없음
    }

    private void RemoveBullet()
    {
        gameObject.SetActive(false);
    }

    IEnumerator GotoTarget(EnemyScript target, Action callBack, float damage)
    {
        while (Vector2.Distance(target.transform.position, transform.position) <= 0.01f)
        {
            transform.position = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime * GameManager.Instance.gameSpeed);
            yield return null;
        }
        target.Hit(damage);
    }

}
