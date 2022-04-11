using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : InteractableObject
{
    [SerializeField] private Room room;
    [SerializeField] private bool isStartingCheckpoint = false;

    [SerializeField] AudioClip activateSound;

    private CheckpointManager checkpointManager;
    private AudioSource checkpointAS;
    

    private void Awake()
    {
        if(room == null)
        {
            Room parentRoom = transform.parent.GetComponent<Room>();
            if(parentRoom != null)
                room = parentRoom;
        }

        checkpointManager = FindObjectOfType<CheckpointManager>();
        if (checkpointManager != null) {
            checkpointManager.AddCheckpoint(this);
            if (isStartingCheckpoint)
                checkpointManager.SetCurrentCheckpoint(this);
        }
        checkpointAS = GetComponent<AudioSource>();
        checkpointAS.clip = activateSound;
    }

    public override void Interact(GameObject interactingObject)
    {
        if (checkpointAS.isPlaying)
            checkpointAS.Stop();
        //checkpointAS.Play();
        interactingObject.GetComponent<PlayerController>().Heal(interactingObject.GetComponent<PlayerController>().getMaxHealth());

        room.ReloadRoom();
        print(gameObject.name);
        checkpointManager.SetCurrentCheckpoint(this);
    }

    public void Reload()
    {
        room.ReloadRoom();
    }
}
