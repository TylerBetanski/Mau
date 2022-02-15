using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LockableObject : MonoBehaviour
{
    private bool _locked = true;
    public bool Locked { get { return _locked; } private set { _locked = value; } }
    public int LockNum { get { return locks.Count; } }
    [SerializeField] protected List<bool> locks = new List<bool>();

    private bool wasLocked = true;

    public void OpenLock(int lockIndex)
    {
        if (lockIndex >= 0 && lockIndex < locks.Count)
            locks[lockIndex] = false;

        if (Locked)
        {
            Unlock();
            Locked = false;
        }

        wasLocked = Locked;
    }

    public void CloseLock(int lockIndex)
    {
        if (lockIndex >= 0 && lockIndex < locks.Count)
            locks[lockIndex] = true;

        if (!wasLocked)
            Lock();

        Locked = true;

        wasLocked = Locked;
    }

    protected abstract void Unlock();
    protected abstract void Lock();
}
