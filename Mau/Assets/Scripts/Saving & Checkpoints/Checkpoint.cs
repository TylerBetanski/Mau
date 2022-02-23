using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : InteractableObject
{
    [SerializeField] private Room room;

    private void Awake()
    {
        if(room == null)
        {
            Room parentRoom = transform.parent.GetComponent<Room>();
            if(parentRoom != null)
                room = parentRoom;
        }
    }

    public override void Interact(GameObject interactingObject)
    {
        room.ReloadRoom();
    }
}
