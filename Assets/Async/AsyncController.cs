using System.Threading.Tasks;
using UnityEngine;

public class AsyncController : MonoBehaviour
{
    [SerializeField] private Target target = null;

    // blocking
    // 0. 함수 호출이 완료되야지만 실행의 제어권이 함수 호출자에게 넘어옴.
    // 1. "I will request scale up to the Target" 메세지는 왜 바로 출력이 안될까?
    // 2. 크기가 변경되는 중간 과정을 볼 수 없는 이유는 뭘까?
    public void OnStartScaleUpWithBlocking()
    {
        Debug.Log("[Blocking] I will request scale up to the Target");
        target.ScaleUpWithBlocking();
        Debug.Log("[Blocking] It finished to scale up so I will process other task");
    }

    // non-blocking with Coroutine
    // 0. 함수 호출 후 실행의 제어권이 바로 함수 호출자에게 넘어옴
    // 1. 아래 두 메세지 중 어느것이 먼저 출력될까? 이유는 뭘까?
    //    - [NonBlocking] Finished scale up? or yet? It doesn't matter, I will process other task
    //    - [Target] Start ScaleUpWithNonBlocking
    // 2. Coroutine을 사용해서 non-blocking 구현하기
    //    - coroutine? https://en.wikipedia.org/wiki/Coroutine
    //    - Coroutines are very similar to threads.
    //    - cooperatively multitasked vs preemptively multitasked
    // 3. yield return new WaitForSeconds가 아니라 Thread.Sleep을 사용하면 어떤 일이 벌어질까? 이유는 뭘까?
    public void OnStartScaleUpWithNonBlocking()
    {
        Debug.Log("[NonBlocking] I will request scale up to the Target");
        StartCoroutine(target.ScaleUpWithNonBlocking((result) => {
        }));
        Debug.Log("[NonBlocking] Finished scale up? or yet? It doesn't matter, I will process other task");
    }

    // sync with return value
    // 0. 함수가 처리된 결과를 리턴값 혹은 참조를 통해서 신경쓰는 것
    public void OnStartScaleUpWithSync()
    {
        Debug.Log("[Blocking] I will request scale up to the Target");
        target.ScaleUpWithSync();
        if ( target.isFinished )
        {
            Debug.Log("[Blocking] It finished to scale up so I will process other task");
        }
    }

    // async with callback
    // 0. 함수가 처리된 결과를 함수 호출자가 신경쓰지 않고, 콜백을 통해 처리하는 것
    //    - 처리가 완료되면 어떻게 처리할지를 함수 객체를 통해 함수를 호출하며 전달해 준 것
    //      그러므로 신경쓰고 있는 상태는 아님
    private bool isTest = false;
    public void OnStartScaleUpWithAsync()
    {
        Debug.Log("[Blocking] I will request scale up to the Target");
        target.ScaleUpWithAsync(() => {
            Debug.Log(isTest); //capturing
            Debug.Log("[Blocking] It finished to scale up so I will process other task");
        });
    }
    

    // non-blocking with Thread
    // 0. Thread 객체를 생성하고, 델리게이트를 전달해서 non-blocking 구현도 가능함
    // 1. transform.localScale 값을 새롭게 생성한 thread에서 처리하면 어떻게 되나?
    // 2. 유니티 컴포넌트는 기본적으로 메인스레드를 사용하도록 강제함. 이유는 뭘까?
    public void OnStartScaleUpWithNonBlocking2()
    {
        Debug.Log("[NonBlocking] I will request scale up to the Target");
        target.ScaleUpWithNonBlockingAndThread();
        Debug.Log("[NonBlocking] Finished scale up? or yet? It doesn't matter, I will process other task");
    }

    // non-blocking with Task
    // 0. Task.Run 등을 통해 델리게이트를 전달해서 non-blocking 구현도 가능함
    // 1. transform.localScale 값을 새롭게 생성한 task를 통해 처리하면 어떻게 되나?
    // 2. task는 경량 thread
    // 3. thread가 같는 문제를 비슷하게 가지고 있음
    // 4. task의 장점 중 하나는 async/await을 이용해 비동기를 동기로 처리할 수 있음. 
    public void OnStartScaleUpWithNonBlocking3()
    {
        Debug.Log("[NonBlocking] I will request scale up to the Target");
        target.ScaleUpWithNonBlockingAndTask();
        Debug.Log("[NonBlocking] Finished scale up? or yet? It doesn't matter, I will process other task");
    }

    // 문제1. A가 3초 간 이동 후 B를 2초 간 크기를 키우려면 어떻게 해야 할까?
    //       > 콜백의 콜백?
    // 문제2. 3초 간 이동, 2초 간 크기를 키운 뒤 모두 끝나면 어떤 처리를 해야 한다면?
    //       > 코루틴이 모두 완료됐는지 감시하는 정도는 가능
    //       > yield return 코루틴 혹은 yield return new WaitUntil 등을 사용해 
    // 문제3. 비동기 네트워크 요청을 효과적으로 하려면?
    //       > A API 요청, B API 요청을 비동기로 요청 후 모두 완료된 경우 처리하게 하려면? > Task를 이용하면됨 WhenAll
}
