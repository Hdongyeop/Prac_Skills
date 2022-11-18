using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isMoving;

    [SerializeField] private float rollSpeed = 3f;

    public GameObject AnchorPoint;
    
    private void Update()
    {
        float tHorizontal = Input.GetAxisRaw("Horizontal");
        float tVertical = Input.GetAxisRaw("Vertical");
        Vector3 tDir = new Vector3(tHorizontal, 0, tVertical);
        
        if(tDir != Vector3.zero)
            Move(tDir);
    }

    void Move(Vector3 dir)
    {
        if (_isMoving) return;
        
        // var anchor = transform.position + (Vector3.down + dir) * 0.25f;
        var anchor = transform.position + Vector3.Scale((dir + Vector3.down), GetComponent<Renderer>().bounds.size / 2);
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
    }
    
    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        AnchorPoint.transform.position = anchor;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        
        _isMoving = false;
        AnchorPoint.transform.localPosition = Vector3.zero;
    }
}
