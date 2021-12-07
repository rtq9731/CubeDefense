using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArrowPool : MonoBehaviour
{
    [SerializeField] GameObject _arrowPrefab = null;
    List<ArrowScript> _arrowPool = new List<ArrowScript>();

    public ArrowScript GetArrow(Vector2 startPos)
    {
        ArrowScript result = _arrowPool.Find(x => !x.gameObject.activeSelf);

        if (result == null)
        {
            result = MakeNewArrow(startPos);
        }
        else
        {
            result.transform.position = startPos;
        }

        return result;
    }

    private ArrowScript MakeNewArrow(Vector2 startPos)
    {
        ArrowScript result = Instantiate(_arrowPrefab, startPos, Quaternion.identity, transform).GetComponent<ArrowScript>();
        _arrowPool.Add(result);
        return result;
    }
}
