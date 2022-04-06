using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalReciever : InteractableObject
{
    [SerializeField] private CrystalEmitter emitter;
    [SerializeField] private bool canBeDisabled = true;

    private void Awake() {
        if(emitter == null) {
            emitter = transform.Find("Emitter").GetComponent<CrystalEmitter>();
        }
    }

    public override void Interact(GameObject interactingObject) {
        if(emitter != null) {
            emitter.Rotate();
        }
    }

    public void Enable() {
        if (emitter != null && canBeDisabled)
            emitter.Activate();
    }

    public void Disable() {
        if (emitter != null && canBeDisabled)
            emitter.Deactivate();
    }
}
