using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGrenadePool : MonoBehaviour
{
    [SerializeField] GameObject _grenadePrefab = null;
    [SerializeField] Transform poolParent = null;
    List<GrenadeScript> _grenadePool = new List<GrenadeScript>();

    public GrenadeScript GetGrenade(Vector2 startPos)
    {
        GrenadeScript result = _grenadePool.Find(x => !x.gameObject.activeSelf);

        if (result == null)
        {
            result = MakeNewGrenade(startPos);
        }
        else
        {
            result.transform.position = startPos;
        }

        result.gameObject.SetActive(true);
        return result;
    }

    private GrenadeScript MakeNewGrenade(Vector2 startPos)
    {
        GrenadeScript result = Instantiate(_grenadePrefab, startPos, Quaternion.identity, poolParent).GetComponent<GrenadeScript>();
        _grenadePool.Add(result);
        return result;
    }
}
