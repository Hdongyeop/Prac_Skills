using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Test : MonoBehaviour
{
    [SerializeField] private Image DogeImg;
    private AsyncOperationHandle _handle;
    
    public void LoadDoge()
    {
        Addressables.LoadAssetAsync<Sprite>("Doge").Completed +=
            (op) =>
            {
                _handle = op;
                DogeImg.sprite = op.Result;
            };
    }

    public void UnLoadDoge()
    {
        Addressables.Release(_handle);
        DogeImg.sprite = null;
    }
}
