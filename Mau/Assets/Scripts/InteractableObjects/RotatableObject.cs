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
		if (!target.CanBeChanged)
			return;

		if (currentState == maxState)
			currentState = 0;
		else
			currentState++;

		animator.SetInteger("CurrentState", currentState);

		gameObject.GetComponent<AudioSource>().Stop();
		gameObject.GetComponent<AudioSource>().Play();

		if (target != null)
		{
			if (currentState == targetState)
				target.OpenLock(targetLockNumber);
			else
				target.CloseLock(targetLockNumber);
		}
    }
	
	public int GetCurrentState() { return currentState; }
	public void SetCurrentState(int state) { 
		state = Mathf.Clamp(state, 0, maxState); 
		currentState = state; 
		animator.SetInteger("CurrentState", currentState); 
	}

    private void OnValidate()
    {
		currentState = Mathf.Clamp(currentState, 0, maxState);
	}
}
