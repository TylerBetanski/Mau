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
        checkpointAS.Play();
        interactingObject.GetComponent<PlayerController>().Heal(interactingObject.GetComponent<PlayerController>().getMaxHealth());

        StartCoroutine(GlowEyes());

        room.ReloadRoom();
        print(gameObject.name);
        checkpointManager.SetCurrentCheckpoint(this);
    }

    public void Reload()
    {
        room.ReloadRoom();
    }

    IEnumerator GlowEyes() {
        float glowAmount = 10;
        Material mat = transform.Find("Art").GetComponent<SpriteRenderer>().material;
        while(glowAmount < 100) {
            glowAmount += 5;
            mat.SetFloat("_em", glowAmount);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSeconds(0.75f);
        while (glowAmount > 10) {
            glowAmount -= 5;
            mat.SetFloat("_em", glowAmount);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
