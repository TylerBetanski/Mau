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

	private Animator animator;

    private void Awake()
    {
		animator = GetComponent<Animator>();
		animator.SetInteger("CurrentState", currentState);

		if (currentState == targetState)
			target.OpenLock(targetLockNumber);
	}

    public override void Interact(GameObject interactingObject)
    {
		if (currentState == maxState)
			currentState = 0;
		else
			currentState++;

		animator.SetInteger("CurrentState", currentState);

		if (target != null)
		{
			if (currentState == targetState)
				target.OpenLock(targetLockNumber);
			else
				target.CloseLock(targetLockNumber);
		}
    }
}
