using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private GameObject _character;
    
    [Header("캐릭터의 어드레스를 입력해주세요")] [SerializeField]
    private string characterAddress = string.Empty;

    private void Start()
    {
        _character = null;
    }

    public void ClickSpawn()
    {
        if (ReferenceEquals(_character, null) == false)
        {
            ReleaseObj();
        }

        Spawn();
    }

    private void Spawn()
    {
        var op = Addressables.InstantiateAsync(characterAddress, new Vector3(Random.Range(-2f, 2f), 5, 0), Quaternion.identity);
        op.Completed += handle =>
        {
            _character = handle.Result;
        };
    }

    private void ReleaseObj()
    {
        Addressables.ReleaseInstance(_character);
    }
}
