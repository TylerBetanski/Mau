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

    private bool playerOn;
    private bool scarabOn;

    private void Awake()
    {
        pushed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pushed) {
            bool correctTrigger = false;
            if (collision.gameObject.tag == "Player")
            {
                correctTrigger = true;
                playerOn = true;
            }

            if ((collision.gameObject.tag == "Scarab"))
            {
                correctTrigger = true;
                scarabOn = true;
            }

            if (correctTrigger)
            {
                GetComponent<SpriteRenderer>().sprite = pushedButton;
                pushed = true;
                if (lockedObject != null)
                    lockedObject.OpenLock(lockNumber);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerOn = false;
        }

        if ((collision.gameObject.tag == "Scarab"))
        {
            scarabOn = false;
        }

        if (pushed && !scarabOn && !playerOn)
        {
            GetComponent<SpriteRenderer>().sprite = button;
            pushed = false;
            if (lockedObject != null)
                lockedObject.CloseLock(lockNumber);
        }
    }
}
