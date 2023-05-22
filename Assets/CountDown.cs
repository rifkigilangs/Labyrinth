using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CountDown : MonoBehaviour
{
    [SerializeField] int duration;

    public UnityEvent OnCountFinished = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();

    Coroutine countCoroutine;

    Sequence seq;

    public void StartCount()
    {
        if(countCoroutine != null)
            StopAllCoroutines();

        countCoroutine = StartCoroutine(CountCoroutine());
    }

    private IEnumerator CountCoroutine()
    {
        for (int i = duration; i >= 0; i--)
        {
            OnCount.Invoke(i);
            yield return new WaitForSecondsRealtime(1);
        }
        OnCountFinished.Invoke();
    }

    // public void StartCount()
    // {
    //     if(isCounting == true)
    //         return;
    //     else
    //         isCounting = true;

    //     seq = DOTween.Sequence();

    //     OnCount.Invoke(duration);
    //     for (int i = duration-1; i >= 0; i--)
    //     {
    //         var count = i;
    //         seq.Append(transform
    //         .DOMove(this.transform.position, 1)
    //         .SetUpdate(true)
    //         .OnComplete(() =>OnCount.Invoke(count)));
    //     }
    //     seq.Append(transform
    //     .DOMove(this.transform.position, 1))
    //     .SetUpdate(true)
    //     .OnComplete(() => { 
    //         isCounting = false;
    //         OnCountFinished.Invoke();
    //         }
    //     );
    // }
}
