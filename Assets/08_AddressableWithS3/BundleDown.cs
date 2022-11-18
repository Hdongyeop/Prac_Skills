using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BundleDown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sizeText;

    [Space] [Header("다운로드를 원하는 번들 또는 번들들에 포함된 레이블중 아무거나 입력해주세요.")] [SerializeField]
    private string lableForBundleDown = string.Empty;

    public void Click_BundleDown()
    {
        Addressables.DownloadDependenciesAsync(lableForBundleDown).Completed += handle =>
        {
            Debug.Log("Download Completed");
            
            Addressables.Release(handle);
        };
        
    }

    public void Click_CheckTheDownloadFileSize()
    {
        Addressables.GetDownloadSizeAsync(lableForBundleDown).Completed += handle =>
        {
            string size = string.Concat(handle.Result, " byte");
            sizeText.text = size;

            Addressables.Release(handle);
        };
    }
}
