using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 movePos;

    public float yPositionLimit = 7f;

    float verticalAxis;

    private void Start()
    {
        verticalAxis = Input.GetAxis("Vertical");
    }

    private void Update()
    {
        if (verticalAxis != 0)
        {
            movePos = transform.position;
            movePos.y += speed * Time.deltaTime * verticalAxis;
            movePos.y = Mathf.Clamp(movePos.y, 7, yPositionLimit); // �ӽ÷� 30���� �ΰ���. Ÿ�� ���̵��� �޶����� �ϸ� �ɵ�.
            transform.position = movePos;
        }
    }
}
