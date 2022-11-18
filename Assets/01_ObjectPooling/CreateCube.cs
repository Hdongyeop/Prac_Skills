using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CreateCoroutine());
    }

    IEnumerator CreateCoroutine()
    {
        while(true)
        {
            yield return null;
            GameObject tObject = ObjectPoolingManager.Instance.GetQueue();
            tObject.transform.position = Vector3.zero;
        }
    }
}
