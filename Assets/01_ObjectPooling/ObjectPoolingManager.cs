using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    [SerializeField] private int objectCount = 1000;
    
    public static ObjectPoolingManager Instance;
    public GameObject goPrefab = null;
    public Queue<GameObject> Queue = new();
    public Transform Parent;
    
    private void Start()
    {
        Instance = this;

        for (int i = 0; i < objectCount; i++)
        {
            GameObject tObject = Instantiate(goPrefab, Vector3.zero, Quaternion.identity, Parent);
            Queue.Enqueue(tObject);
            tObject.SetActive(false);
        }
    }

    public void InsertQueue(GameObject pObject)
    {
        Queue.Enqueue(pObject);
        pObject.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject tObjet = Queue.Dequeue();
        tObjet.SetActive(true);
        return tObjet;
    }
}
