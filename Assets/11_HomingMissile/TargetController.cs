using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float speed;
    
    private void Update()
    {
        float tVertical = Input.GetAxisRaw("Vertical");
        float tHorizontal = Input.GetAxisRaw("Horizontal");

        Vector3 moveDir = new Vector3(tHorizontal, tVertical, 0);
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
