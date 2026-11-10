using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform platform = null;
    [SerializeField]
    private Transform endPoint = null;
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float waitDuration = 2.0f;

    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;

    private Coroutine movingCoroutine = null;
    private bool moveToEnd = true;

    private void Awake()
    {
        startPosition = transform.position;
        endPosition = endPoint.position;
    }

    private void OnEnable()
    {
        ClearCoroutine();
        if(moveToEnd)
        {
            MoveToEnd();
        }
        else
        {
            MoveToStart();
        }
    }

    private void OnDisable()
    {
        ClearCoroutine();
    }

    private void ClearCoroutine()
    {
        if (movingCoroutine != null)
        {
            StopCoroutine(movingCoroutine);
        }

        movingCoroutine = null;
    }

    private void MoveToEnd()
    {
        moveToEnd = true;
        movingCoroutine = StartCoroutine(MovePlatform());
    }

    private void MoveToStart()
    {
        moveToEnd = false;
        movingCoroutine = StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
     while(true)
        {
            Vector3 targetPos = moveToEnd ? endPosition : startPosition;
            // pause here for a frame, next frame start next line
            yield return null;

            // time = distance / speed;
            float duration = (platform.transform.position - targetPos).magnitude / moveSpeed;

            Tween moveTween;

            if (platform.GetComponent<Rigidbody>() != null)
            {
                // rigidbody allows physics collisions
                moveTween = platform.GetComponent<Rigidbody>().DOMove(targetPos, duration);
            }
            else
            {
                moveTween = platform.DOMove(targetPos, duration);
            }

            // come back when this animation is complete
            yield return moveTween.WaitForCompletion();

            moveTween.Kill();
            // pause for the wait duration
            yield return new WaitForSeconds(waitDuration);
            moveToEnd = !moveToEnd;
        }
    }
}