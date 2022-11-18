using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisCube : MonoBehaviour
{
    [SerializeField] private GameObject goPrefab = null;
    [SerializeField] private float force = 0f;
    [SerializeField] Vector3 offset = Vector3.zero;

    public void Explosion()
    {
        GameObject _clone = Instantiate(goPrefab, transform.position, Quaternion.identity);
        Rigidbody[] _rigids = _clone.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < _rigids.Length; i++)
        {
            _rigids[i].AddExplosionForce(force, transform.position + offset, 10f);
        }
        
        gameObject.SetActive(false);
    }
}
