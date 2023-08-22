using System.Collections;
using UnityEngine;
using DG.Tweening;

public class YoyoMotion : MonoBehaviour
{
    //public Vector3 startPoint;
    public Transform endPoint;
    public float motionDuration = 1.0f;
    public float delayBeforeStart = 2.0f;

    private void Start()
    {
       // startPoint = transform.position;
        StartCoroutine(StartYoyoMotionWithDelay());
    }

    private IEnumerator StartYoyoMotionWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        StartYoyoMotion();
    }

    private void StartYoyoMotion()
    {
        transform.DOMove(endPoint.position, motionDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
