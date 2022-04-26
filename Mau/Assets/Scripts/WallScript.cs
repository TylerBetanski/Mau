using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public bool lock1 = false;
    public bool lock2 = false;
    public bool lock3 = false;

    public void setLock(int lockNum, bool val) {
        if (lockNum == 1) lock1 = val;
        else if(lockNum == 2) lock2 = val;
        else if(lockNum == 3) lock3 = val;

        if (lock1 && lock2 && lock3)
            GetComponent<LockableTiles>().CloseLock(0);
        else
            GetComponent<LockableTiles>().OpenLock(0);
    }
}
