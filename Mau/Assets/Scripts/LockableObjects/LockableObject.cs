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

    private bool canChange = true;

    public void OpenLock(int lockIndex)
    {
        if (canChange)
        {
            if (lockIndex >= 0 && lockIndex < locks.Count)
                locks[lockIndex] = false;

            if (Locked && CanOpen())
            {
                Unlock();
                canChange = false;
                Locked = false;
            }

            wasLocked = Locked;
        }
    }

    public void CloseLock(int lockIndex)
    {
        if (canChange)
        {
            if (lockIndex >= 0 && lockIndex < locks.Count)
                locks[lockIndex] = true;

            if (!wasLocked)
                Lock();

            Locked = true;

            wasLocked = Locked;
        }
    }

    private bool CanOpen()
    {
        for(int i = 0; i < locks.Count; i++)
        {
            if (locks[i])
                return false;
        }
        return true;
    }

    protected abstract void Unlock();
    protected abstract void Lock();
}
