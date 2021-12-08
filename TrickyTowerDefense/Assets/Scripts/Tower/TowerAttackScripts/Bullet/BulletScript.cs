using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Coroutine co = null;

    public void Fire(EnemyScript target, float damage, Vector3 scale)
    {
        transform.localScale = scale;
        co = StartCoroutine(GotoTarget(target, () => { gameObject.SetActive(false); }, damage));
        target.OnEnmeyDeath += RemoveBullet; // 어차피 켜질 때 초기화 해줘서 상관 없음
        target.OnEnmeyDeath += () => StopCoroutine(co);
    }

    private void RemoveBullet()
    {
        gameObject.SetActive(false);
    }

    IEnumerator GotoTarget(EnemyScript target, Action callBack, float damage)
    {
        while (Vector2.Distance(target.transform.position, transform.position) >= 0.01f)
        {
            Vector3 dir = target.transform.position - transform.position;

            transform.Translate(speed * Time.deltaTime * GameManager.Instance.gameSpeed * dir.normalized);
            yield return null;
        }
        target.Hit(damage);
        callBack();
    }

}
