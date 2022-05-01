using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalReciever : InteractableObject
{
    [SerializeField] private CrystalEmitter emitter;
    [SerializeField] private bool canBeDisabled = true;
    [SerializeField] private bool emitLaser = true;
    private bool noEmitActivated = false;

    private void Awake() {
        if(emitter == null) {
            emitter = transform.Find("Emitter").GetComponent<CrystalEmitter>();
        }
    }

    public override void Interact(GameObject interactingObject) {
        if(emitter != null && emitLaser) {
            emitter.Rotate();
        }
    }

    public void Enable() {
        if (emitter != null && canBeDisabled && emitLaser)
            emitter.Activate();

        if (!emitLaser && !noEmitActivated) {
            GetComponent<LockOpener>().RecieveSignal();
            noEmitActivated = true;
        }
    }

    public void Disable() {
        if (emitter != null && canBeDisabled && emitLaser)
            emitter.Deactivate();
    }
}
