using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody _myRigid = null;

    private void OnEnable()
    {
        if (_myRigid == null)
            _myRigid = GetComponent<Rigidbody>();

        _myRigid.velocity = Vector3.zero;
        _myRigid.AddExplosionForce(1000f, transform.position, 1f);

        StartCoroutine(DestroyCube());
    }

    IEnumerator DestroyCube()
    {
        yield return new WaitForSeconds(1f);
        ObjectPoolingManager.Instance.InsertQueue(gameObject);
    }
}
