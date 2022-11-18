using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Create : MonoBehaviour
{
    public GameObject parentObj;
    
    public void CreateYena()
    {
        Addressables.InstantiateAsync("ImgEnbi", new Vector3(500f, 350f), Quaternion.identity, parentObj.transform);
    }
}
