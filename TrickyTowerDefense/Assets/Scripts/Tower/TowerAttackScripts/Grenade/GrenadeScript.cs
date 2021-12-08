using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] LayerMask whatIsEnemy;    
    Coroutine co = null;

    public void Fire(EnemyScript target, float damage, Vector3 scale, float splashRadius)
    {
        transform.localScale = scale;
        co = StartCoroutine(GotoTarget(target, () => { gameObject.SetActive(false); }, damage, splashRadius));
        target.OnEnmeyDeath += RemoveArrow; // 어차피 켜질 때 초기화 해줘서 상관 없음
        target.OnEnmeyDeath += () =>
        {
            if (co != null)
            {
                StopCoroutine(co);
            }
        };
    }

    private void RemoveArrow()
    {
        gameObject.SetActive(false);
    }

    public void Boom(float damage, float splashRadius)
    {  
        Collider2D[] colliders = null;

        if ((colliders = Physics2D.OverlapCircleAll(transform.position, splashRadius, whatIsEnemy)).Length >= 0)
        {
            foreach (var item in colliders)
            {
                item.GetComponent<EnemyScript>().Hit(damage);
            }
        }
    }

    IEnumerator GotoTarget(EnemyScript target, Action callBack, float damage, float splashRadius)
    {
        while (Vector2.Distance(target.transform.position, transform.position) >= 0.01f)
        {
            Vector3 dir = target.transform.position - transform.position;

            transform.Translate(speed * Time.deltaTime * GameManager.Instance.gameSpeed * dir.normalized);
            yield return null;
        }
        Boom(damage, splashRadius);
        callBack();
    }
}
