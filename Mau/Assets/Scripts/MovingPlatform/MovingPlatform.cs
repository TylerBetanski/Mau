using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, ISignalReciever
{
    public bool Moving { get { return moving; } }

    [SerializeField] private bool alwaysMove = false;
    [SerializeField] private Transform platform;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float moveTime = 6.0f;
    [SerializeField] private float moveBackDelay = 3.0f;

    private bool atStart = true;
    private bool atEnd = false;
    private bool moving = false;

    private WaitForSeconds fixedDeltaWait;
    private WaitForSeconds moveBackWait;

    private void Awake()
    {
        if (platform == null)
            platform = transform.Find("Platform");
        if (endPoint == null)
            endPoint = transform.Find("EndPoint");

        platform.position = transform.position;

        fixedDeltaWait = new WaitForSeconds(Time.fixedDeltaTime);
        moveBackWait = new WaitForSeconds(moveBackDelay);


    }

    private IEnumerator Move()
    {
        float time = 0;

        moving = true;

        while (time < moveTime) {
            time += Time.fixedDeltaTime;
            yield return fixedDeltaWait;

            if(atStart) platform.position = Vector3.Lerp(transform.position, endPoint.position, time / moveTime);
            else if (atEnd) platform.position = Vector3.Lerp(endPoint.position, transform.position, time / moveTime);
        }

        moving = false;

        if(atStart) {
            atStart = false;
            atEnd = true;
        } else {
            atEnd = false;
            atStart = true;
        }

        if (alwaysMove)
            StartCoroutine(Move());
        else if(!alwaysMove && atEnd)
        {
            yield return moveBackWait;
            StartCoroutine(Move());
        }
    }

    public void RecieveSignal()
    {
        if (!alwaysMove && !moving)
            StartCoroutine(Move());
    }

    private void OnValidate()
    {
        if (moveTime < 1)
            moveTime = 1;
    }

    private void OnDrawGizmosSelected() {
        if(endPoint != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, endPoint.position);
        }
    }

    private void OnEnable() {
        if (alwaysMove)
            StartCoroutine(Move());
    }
}
