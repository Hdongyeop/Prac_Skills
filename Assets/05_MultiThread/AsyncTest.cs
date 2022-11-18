using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Unity.Jobs;

public class AsyncTest : MonoBehaviour
{
    #region Coroutine

    // private void Start()
    // {
    //     Debug.LogFormat("현재 쓰레드 ID : {0}",Thread.CurrentThread.ManagedThreadId);
    //     StartCoroutine(CoStart());
    // }
    //
    // IEnumerator CoStart()
    // {
    //     Debug.LogFormat("현재 쓰레드 ID : {0}",Thread.CurrentThread.ManagedThreadId);
    //     Debug.LogFormat("현재 프레임 : {0}",Time.frameCount);
    //     yield return CoTest();
    //     Debug.LogFormat("현재 프레임 : {0}",Time.frameCount);
    // }
    //
    // IEnumerator CoTest()
    // {
    //     Debug.LogFormat("현재 쓰레드 ID : {0}",Thread.CurrentThread.ManagedThreadId);
    //     Debug.LogFormat("작업 완료");
    //     yield return null;
    // }

    #endregion

    #region Async

    // private async void Start()
    // {
    //     Debug.LogFormat("현재 쓰레드 : {0}", Thread.CurrentThread.ManagedThreadId);
    //     Debug.LogFormat("현재 프레임 : {0}", Time.frameCount);
    //     await TestAsync();
    //     Debug.LogFormat("현재 프레임 : {0}", Time.frameCount);
    // }
    //
    // async Task TestAsync()
    // {
    //     await Task.Run(() =>
    //     {
    //         Debug.Log("작업 완료");
    //         Debug.LogFormat("현재 쓰레드 : {0}", Thread.CurrentThread.ManagedThreadId);
    //     });
    // }

    #endregion

    #region JOB

    private void Start()
    {
        Debug.LogFormat("현재 쓰레드 : {0}", Thread.CurrentThread.ManagedThreadId);
        StartCoroutine(CoJob());
    }

    IEnumerator CoJob()
    {
        TestJob testJob;
        JobHandle Handle = testJob.Schedule();
        yield return null;
        Handle.Complete();
    }
    
    struct TestJob : IJob
    {
        public void Execute()
        {
            Debug.LogFormat("현재 쓰레드 : {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }

    #endregion
}
