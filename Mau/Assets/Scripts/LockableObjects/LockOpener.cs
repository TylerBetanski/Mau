using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOpener : MonoBehaviour, ISignalReciever
{
    [SerializeField] Door targetDoor;
    [SerializeField] int lockNum;

    private bool activated = false;

    public void RecieveSignal()
    {
        activated = !activated;

        if(targetDoor != null)
        {
            if(activated)
            {
                targetDoor.OpenLock(lockNum);
            } else {
                targetDoor.CloseLock(lockNum);
            }
        }
    }
}
