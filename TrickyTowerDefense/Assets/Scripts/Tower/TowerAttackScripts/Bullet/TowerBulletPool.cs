using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;
    List<BulletScript> bulletPool = new List<BulletScript>();

    public BulletScript GetBullet(Vector2 position)
    {
        BulletScript result = bulletPool.Find(x => !x.gameObject.activeSelf);

        if (result == null)
        {
            result = MakeNewBullet(position);
        }
        else
        {
            result.transform.position = position;
        }

        return result;
    }

    private BulletScript MakeNewBullet(Vector2 startPos)
    {
        BulletScript result = Instantiate(bulletPrefab, startPos, Quaternion.identity, transform).GetComponent<BulletScript>();
        bulletPool.Add(result);
        return result;
    }
}
