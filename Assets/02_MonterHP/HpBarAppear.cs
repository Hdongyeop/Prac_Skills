using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarAppear : MonoBehaviour
{
    [SerializeField] private GameObject _goPrefab = null;
    private List<Transform> _objectList = new List<Transform>();
    private List<GameObject> _hpBarList = new List<GameObject>();

    private Camera _cam = null;

    private void Start()
    {
        _cam = Camera.main;

        GameObject[] _objects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < _objects.Length; i++)
        {
            _objectList.Add(_objects[i].transform);
            GameObject _hpBar = Instantiate(_goPrefab, _objects[i].transform.position, Quaternion.identity, transform);
            _hpBarList.Add(_hpBar);
        }
    }

    private void Update()
    {
        for(int i=0;i<_objectList.Count;i++)
        {
            _hpBarList[i].transform.position = _cam.WorldToScreenPoint(_objectList[i].position + new Vector3(0, 1.15f, 0));
        }
    }
}
