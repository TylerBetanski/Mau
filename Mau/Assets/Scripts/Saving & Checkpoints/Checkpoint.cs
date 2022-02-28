using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : InteractableObject
{
    [SerializeField] private Room room;
    [SerializeField] private bool isStartingCheckpoint = false;

    private CheckpointManager checkpointManager;

    private void Awake()
    {
        if(room == null)
        {
            Room parentRoom = transform.parent.GetComponent<Room>();
            if(parentRoom != null)
                room = parentRoom;
        }

        checkpointManager = FindObjectOfType<CheckpointManager>();
        if (checkpointManager == null) {
            checkpointManager.AddCheckpoint(this);
            if (isStartingCheckpoint)
                checkpointManager.SetCurrentCheckpoint(this);
        }
    }

    public override void Interact(GameObject interactingObject)
    {
        room.ReloadRoom();
    }

    public void Reload()
    {
        room.ReloadRoom();
    }
}
