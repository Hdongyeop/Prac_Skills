using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUsingLerp : MonoBehaviour
{
    private float _curTime;
    private Vector3 _originPos;

    public Button btnStart;
    public Button btnReset;
    public Transform destPos;
    public float totalTime;

    private void Start()
    {
        _originPos = transform.position;
        
        btnStart.onClick.AddListener(OnButtonClick_Lerp);
        btnReset.onClick.AddListener(OnButtonClick_Reset);
    }

    public void OnButtonClick_Lerp()
    {
        StartCoroutine(CoStartLerp());
    }

    IEnumerator CoStartLerp()
    {
        while (_curTime < totalTime)
        {
            _curTime += Time.deltaTime;
            transform.position = Vector3.Lerp(_originPos, destPos.position, _curTime / totalTime);
            yield return null;
        }
    }

    public void OnButtonClick_Reset()
    {
        _curTime = 0;
        transform.position = _originPos;
    }
}
