using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUsingAnimationCurve : MonoBehaviour
{
    private float _curTime;
    private Vector3 _originPos;
    
    public Button btnStart;
    public Button btnReset;
    public float totalTime;
    public Transform destPos;
    public AnimationCurve animCurve;
    
    private void Start()
    {
        _originPos = transform.position;
        
        btnStart.onClick.AddListener(OnButtonClick_AnimCurve);
        btnReset.onClick.AddListener(OnButtonClick_Reset);
    }
    
    public void OnButtonClick_AnimCurve()
    {
        StartCoroutine(CoStartAnimCurve());
    }
    
    IEnumerator CoStartAnimCurve()
    {
        while (_curTime < totalTime)
        {
            _curTime += Time.deltaTime;
            var percent = animCurve.Evaluate(_curTime / totalTime);
            transform.position = Vector3.Lerp(_originPos, destPos.position, percent);
            yield return null;
        }
    }
    
    public void OnButtonClick_Reset()
    {
        _curTime = 0;
        transform.position = _originPos;
    }
}
