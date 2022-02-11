using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private bool _canInteract = true;
    public bool CanInteract { get { return _canInteract; } protected set { _canInteract = value; } }

    public abstract void Interact();
}
