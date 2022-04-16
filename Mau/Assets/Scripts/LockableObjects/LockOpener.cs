using UnityEngine;

public class LockOpener : MonoBehaviour, ISignalReciever
{
    [SerializeField] LockableObject target;
    [SerializeField] int lockNum;
    [SerializeField] private bool open = true;

    private bool activated = false;

    public void RecieveSignal()
    {
        activated = !activated;

        if(target != null)
        {
            if(activated)
            {
                if (open)
                    target.OpenLock(lockNum);
                else
                    target.CloseLock(lockNum);
            } else {
                if (open)
                    target.CloseLock(lockNum);
                else
                    target.OpenLock(lockNum);
            }
        }
    }
}
