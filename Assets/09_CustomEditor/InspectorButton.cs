using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorButton : MonoBehaviour
{
    public List<Transform> childTr = new();
    public bool includeSelf = false;

    public void FindChildAndAddToList()
    {
        childTr.Clear();
        foreach (var child in GetComponentsInChildren<Transform>())
        {
            if(includeSelf == false && child == transform) continue;
            childTr.Add(child);
        }
    }

    public void ClearList()
    {
        childTr.Clear();
    }
}