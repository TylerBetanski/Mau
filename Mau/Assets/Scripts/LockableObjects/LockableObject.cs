using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LockableObject : MonoBehaviour
{
    public bool Locked { get { return IsLocked(); } }
    public int LockNum { get { return locks.Count; } }
    [SerializeField] protected List<bool> locks = new List<bool>();

    private bool wasLocked;

    public void OpenLock(int lockIndex)
    {
        if (lockIndex > 0 && lockIndex < locks.Count)
            locks[lockIndex] = false;

        if (!Locked)
            Unlock();

        wasLocked = Locked;
    }

    public void CloseLock(int lockIndex)
    {
        if (lockIndex > 0 && lockIndex < locks.Count)
            locks[lockIndex] = true;

        if(!wasLocked)
            Lock();

        wasLocked = Locked;
    }

    protected abstract void Unlock();
    protected abstract void Lock();

    private bool IsLocked()
    {
        for(int i = 0; i < locks.Count; i++)
        {
            if (locks[i])
                return true;
        }

        return false;
    }
}
