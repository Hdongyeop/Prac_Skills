using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rigid;
    public float angleChangingSpeed;
    public float movementSpeed;

    private void FixedUpdate()
    {
        Vector2 dir = (Vector2) target.position - rigid.position;
        dir.Normalize();

        float rotateAmount = Vector3.Cross(dir, transform.up).z;
        rigid.angularVelocity = -angleChangingSpeed * rotateAmount;
        Debug.Log($"{rotateAmount}");
        Debug.Log($"{rigid.angularVelocity}");
        rigid.velocity = transform.up * movementSpeed;
    }
}
