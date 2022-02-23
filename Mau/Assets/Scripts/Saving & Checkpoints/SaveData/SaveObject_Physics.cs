using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SaveObject_Physics : SaveObject
{
    private Rigidbody2D rb2D;

    protected override void InitializeSaveData()
    {
        rb2D = GetComponent<Rigidbody2D>();
        saveData = new ObjectSaveData_Physics(transform, rb2D);
    }

    public override void OverrideSaveData()
    {
        saveData = new ObjectSaveData_Physics(transform, rb2D);
    }

    public override void ReloadSaveData()
    {
        base.ReloadSaveData();
        rb2D.velocity = (saveData as ObjectSaveData_Physics).GetVelocity();
        rb2D.angularVelocity = (saveData as ObjectSaveData_Physics).angularVelocity;
    }
}
