using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 movePos;

    float verticalAxis;

    private void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        if (verticalAxis != 0)
        {
            movePos = transform.position;
            movePos.y += speed * Time.deltaTime * verticalAxis;
            Mathf.Clamp(movePos.y, 0, 30); // �ӽ÷� 30���� �ΰ���. Ÿ�� ���̵��� �޶����� �ϸ� �ɵ�.
            transform.position = movePos;
        }
    }
}
