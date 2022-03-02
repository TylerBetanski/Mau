using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] bool pushed;
    [SerializeField] Sprite button;
    [SerializeField] Sprite pushedButton;
    [SerializeField] LockableObject lockedObject;
    [SerializeField] int lockNumber;

    private void Awake()
    {
        pushed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pushed)
        {
            GetComponent<SpriteRenderer>().sprite = pushedButton;
            pushed = true;
            if (lockedObject != null)
                lockedObject.OpenLock(lockNumber);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (pushed)
        {
            GetComponent<SpriteRenderer>().sprite = button;
            pushed = false;
            if (lockedObject != null)
                lockedObject.CloseLock(lockNumber);
        }
    }
}
