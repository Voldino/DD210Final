using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 moveDirection;

    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection));
    }
}
