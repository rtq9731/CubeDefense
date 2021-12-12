using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float _speed = 1f;

    SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void Fire(EnemyScript target, float damage, Vector3 scale)
    {
        Vector2 targetVector = target.transform.position - transform.position;
        _sr.flipX = targetVector.x >= 0 ? true : false;

        transform.localScale = scale;
        StartCoroutine(GotoTarget(target, () => { gameObject.SetActive(false); }, damage));
    }

    IEnumerator GotoTarget(EnemyScript target, Action callBack, float damage)
    {
        while (Vector2.Distance(target.transform.position, transform.position) >= 0.1f)
        {
            Vector3 dir = target.transform.position - transform.position;

            transform.Translate(_speed * Time.deltaTime * GameManager.Instance.gameSpeed * dir.normalized);

            if (!target.gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                yield break;
            }

            yield return null;
        }
        target.Hit(damage);
        callBack();
    }

}
