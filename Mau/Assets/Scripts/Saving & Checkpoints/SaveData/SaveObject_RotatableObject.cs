using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotatableObject))]
public class SaveObject_RotatableObject : SaveObject
{
    private RotatableObject rotatableObject;

    protected override void InitializeSaveData()
    {
        rotatableObject = GetComponent<RotatableObject>();
        saveData = new ObjectSaveData_RotatableObject(transform, rotatableObject);
    }

    public override void OverrideSaveData()
    {
        saveData = new ObjectSaveData_RotatableObject(transform, rotatableObject);
    }

    public override void ReloadSaveData()
    {
        base.ReloadSaveData();
        rotatableObject.SetCurrentState((saveData as ObjectSaveData_RotatableObject).currentState);
    }
}
