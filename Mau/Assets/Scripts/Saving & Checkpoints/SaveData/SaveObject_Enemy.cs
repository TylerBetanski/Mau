using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject_Enemy : SaveObject
{
    private EnemyMovement em;

    private bool removeOnLoad = false;

    protected override void InitializeSaveData()
    {
        em = GetComponent<EnemyMovement>();
        saveData = new ObjectSaveData_Enemy(transform, em);
    }

    public override void OverrideSaveData()
    {
        saveData = new ObjectSaveData_Enemy(transform, em);
    }

    public override void ReloadSaveData()
    {
        transform.position = saveData.GetPosition();
        transform.localRotation = Quaternion.Euler(saveData.GetRotation());
        transform.localScale = saveData.GetScale();

        em.MoveSpeed = ((ObjectSaveData_Enemy)saveData).moveSpeed;

        if (removeOnLoad)
            Destroy(gameObject);
    }

    public void SetRemoveOnLoad(bool b)
    {
        removeOnLoad = b;
    }
}
