using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingCollectable : CollectableObject
{
    [SerializeField] private Room roomToSave;

    private void Awake()
    {
        if(roomToSave == null)
        {
            Room room = transform.parent.GetComponent<Room>();
            if (room != null)
                roomToSave = room;
        }
    }

    public override void Collect(PlayerController PC)
    {
        if(roomToSave != null)
        {
            roomToSave.SaveRoom();
        }
    }
}
