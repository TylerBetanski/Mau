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

    [SerializeField] AudioClip flipSound;
    private AudioSource leverAudio;
    private void Awake()
    {
        flipped = false;
        leverAudio = GetComponent<AudioSource>();
        leverAudio.clip = flipSound;
    }

    public override void Interact(GameObject interactingObject)
    {
        if (leverAudio.isPlaying)
            leverAudio.Stop();
        leverAudio.Play();
        if (lockedObject != null)
            lockedObject.SetLock(lockNumber, !lockedObject.GetLockValue(lockNumber));

        if (flipped)
        {
            GetComponent<SpriteRenderer>().sprite = lever;
            flipped = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = flippedLever;
            flipped = true;
        }
    }
}
