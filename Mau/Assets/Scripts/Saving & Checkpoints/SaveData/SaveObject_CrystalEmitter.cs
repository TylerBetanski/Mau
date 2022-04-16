using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CrystalEmitter))]
public class SaveObject_CrystalEmitter : SaveObject
{
    private CrystalEmitter emitter;

    protected override void InitializeSaveData() {
        emitter = GetComponent<CrystalEmitter>();
        saveData = new ObjectSavaData_CrystalEmitter(transform, emitter);
    }

    public override void OverrideSaveData() {
        saveData = new ObjectSavaData_CrystalEmitter(transform, emitter);
    }

    public override void ReloadSaveData() {
        base.ReloadSaveData();
        emitter.setActive((saveData as ObjectSavaData_CrystalEmitter).active);
        emitter.setAngle((saveData as ObjectSavaData_CrystalEmitter).angle);
    }
}
