using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : LockableObject
{
    [SerializeField] private float doorHeight = 3;
    [SerializeField] private float openTime;

    WaitForSeconds doorTime;
    private new BoxCollider2D collider;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private bool opening = false;
    private bool closing = false;

    private void Awake()
    {
        doorTime = new WaitForSeconds(Time.fixedDeltaTime);

        collider = GetComponent<BoxCollider2D>();

        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, doorHeight, 0);

        if (!Locked)
            Unlock();
    }

    protected override void Lock()
    {
        StopCoroutine("OpenDoor");
        StartCoroutine(CloseDoor());
    }

    protected override void Unlock()
    {
        StopCoroutine("CloseDoor");
        StartCoroutine(OpenDoor());
        SignalTransmitter transmitter = GetComponent<SignalTransmitter>();
        if (transmitter != null)
            transmitter.TransmitSignal();
    }

    IEnumerator OpenDoor()
    {
        opening = true;
        closing = false;

        float time = 0;
        while (time < openTime && opening)
        {
            float progress = time / openTime;

            transform.position = Vector3.Lerp(startPosition, endPosition, progress);
            collider.offset = new Vector2(0, progress * -doorHeight);

            time += Time.fixedDeltaTime;
            yield return doorTime;
        }

        transform.position = endPosition;
        collider.offset = new Vector2(0, 0);
    }

    IEnumerator CloseDoor()
    {
        closing = true;
        opening = false;

        float time = 0;
        while (time < openTime && closing)
        {
            float progress = time / openTime;

            transform.position = Vector3.Lerp(endPosition, startPosition, progress);
            collider.offset = new Vector2(0, (1 - progress) * -doorHeight);

            time += Time.fixedDeltaTime;
            yield return doorTime;
        }

        transform.position = startPosition;
        collider.offset = new Vector2(0, 0);
    }
}
