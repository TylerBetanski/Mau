using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject_Pot : SaveObject
{
    [SerializeField] private GameObject potPrefab;

    protected override void InitializeSaveData() {
        saveData = new ObjectSaveData_Pot(transform, false);
    }

    public override void OverrideSaveData() {
        saveData = new ObjectSaveData_Pot(transform, transform.childCount != 1);
    }

    public override void ReloadSaveData() {
        for(int i = 0; i < transform.childCount; ++i) {
            Destroy(transform.GetChild(i).gameObject);
        }

        base.ReloadSaveData();
        if(((ObjectSaveData_Pot)saveData).isPotDestroyed) {
            
        } else {
            GameObject newPot = Instantiate(potPrefab);
            newPot.transform.parent = transform;
            newPot.transform.position = transform.position;
        }
    }

}
