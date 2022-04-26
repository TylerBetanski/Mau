using UnityEngine;

public class LockOpener : MonoBehaviour, ISignalReciever
{
    [SerializeField] WallScript target;
    [SerializeField] int lockNum;
    [SerializeField] private bool open = true;
    [SerializeField] private bool openAllThree = false;

    private bool activated = false;

    public void RecieveSignal()
    {
        activated = !activated;

        if(target != null)
        {

            if(activated)
            {
                if (open) {
                    if (openAllThree) {
                        target.setLock(1, true);
                        target.setLock(2, true);
                        target.setLock(3, true);
                    } else
                        target.setLock(lockNum, true);
                } else {
                    if (openAllThree) {
                        target.setLock(1, false);
                        target.setLock(2, false);
                        target.setLock(3, false);
                    } else
                        target.setLock(lockNum, false);
                }
            } else {
                if (open) {
                    if (openAllThree) {
                        target.setLock(1, false);
                        target.setLock(2, false);
                        target.setLock(3, false);
                    } else
                        target.setLock(lockNum, false);
                } else {
                    if (openAllThree) {
                        target.setLock(1, true);
                        target.setLock(2, true);
                        target.setLock(3, true);
                    } else
                        target.setLock(lockNum, true);
                }
            }
        }
    }
}
