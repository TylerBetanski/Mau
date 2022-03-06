using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractableObject
{
    [SerializeField] bool flipped;
    [SerializeField] Sprite lever;
    [SerializeField] Sprite flippedLever;
    [SerializeField] LockableObject lockedObject;
    [SerializeField] int lockNumber;
    private void Awake()
    {
        flipped = false;
    }

    public override void Interact(GameObject interactingObject)
    {
        if (flipped)
        {
            GetComponent<SpriteRenderer>().sprite = lever;
            flipped = false;
            if (lockedObject != null)
                lockedObject.CloseLock(lockNumber);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = flippedLever;
            flipped = true;
            if (lockedObject != null)
                lockedObject.OpenLock(lockNumber);
        }
    }
}
