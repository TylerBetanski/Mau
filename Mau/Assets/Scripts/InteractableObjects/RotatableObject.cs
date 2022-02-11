using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotatableObject : InteractableObject
{
	[SerializeField] LockableObject target;
	[SerializeField] int targetLockNumber;
	[SerializeField, Header("States")] int currentState;
	[SerializeField] int maxState;
	[SerializeField] int targetState;

    private void Awake()
    {
		maxState = Mathf.Clamp(maxState, 0, target.LockNum);
    }

    public override void Interact()
    {
		if (currentState == maxState)
			currentState = 0;
		else
			currentState++;

		// Animate the Rotation

		if (currentState == targetState)
			target.OpenLock(targetLockNumber);
		else
			target.CloseLock(targetLockNumber);
    }
}
