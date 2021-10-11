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
            movePos.y = Mathf.Clamp(movePos.y, 7, yPositionLimit); // 임시로 30으로 두겟음. 타워 높이따라 달라지게 하면 될듯.
            transform.position = movePos;
        }
    }
}
