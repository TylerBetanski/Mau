using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LockableObject : MonoBehaviour
{
    private bool _locked = true;
    public bool Locked { get { return _locked; } private set { _locked = value; } }
    private bool _canBeChanged = true;
    public bool CanBeChanged { get { return _canBeChanged; } private set { _canBeChanged = value; } }

    public int LockNum { get { return locks.Count; } }
    [SerializeField] protected List<bool> locks = new List<bool>();
    [SerializeField] private bool reusable = true;

    private bool wasLocked = true;
    

    public void OpenLock(int lockIndex)
    {
        if (CanBeChanged)
        {
            if (lockIndex >= 0 && lockIndex < locks.Count)
                locks[lockIndex] = false;

            if (Locked && CanOpen())
            {
                Unlock();
                Locked = false;

                if(!reusable)
                    CanBeChanged = false;
            }

            wasLocked = Locked;
        }
    }

    public void CloseLock(int lockIndex)
    {
        if (CanBeChanged)
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
