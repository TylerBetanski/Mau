using UnityEngine;

public class LockOpener : MonoBehaviour, ISignalReciever
{
    [SerializeField] WallScript target;
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
                    target.setLock(lockNum, true);
                else
                    target.setLock(lockNum, false);
            } else {
                if (open)
                    target.setLock(lockNum, false);
                else
                    target.setLock(lockNum, true);
            }
        }
    }
}
