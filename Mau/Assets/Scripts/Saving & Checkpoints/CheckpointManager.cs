using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private List<Checkpoint> checkpoints = new List<Checkpoint>();
    private Checkpoint currentCheckpoint;
    private void Awake()
    {
        CreateInstance();
    }

    public void ResetAllCheckpoints()
    {
        for(int i = 0; i < checkpoints.Count; i++)
        {
            checkpoints[i].Reload();
        }
    }

    public void ReloadWorld(GameObject player)
    {
        ResetAllCheckpoints();
        player.transform.position = currentCheckpoint.gameObject.transform.position + new Vector3(0, 2.5f, 0);
    }

    private void CreateInstance()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void AddCheckpoint(Checkpoint checkpoint)
    {
        checkpoints.Add(checkpoint);
    }
    
    public void SetCurrentCheckpoint(Checkpoint checkpoint)
    {
        currentCheckpoint = checkpoint;
    }
}
