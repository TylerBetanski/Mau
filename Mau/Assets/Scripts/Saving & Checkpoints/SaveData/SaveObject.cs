using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    protected ObjectSaveData saveData;

    private void Awake()
    {
        InitializeSaveData();
    }

    protected virtual void InitializeSaveData()
    {
        saveData = new ObjectSaveData(transform);
    }

    public virtual void OverrideSaveData()
    {
        saveData = new ObjectSaveData(transform);
    }

    public virtual void ReloadSaveData()
    {
        transform.position = saveData.GetPosition();
        transform.localRotation = Quaternion.Euler(saveData.GetRotation());
        transform.localScale = saveData.GetScale();
    }
}
