using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private List<Checkpoint> checkpoints;
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

    public void ReloadWorld()
    {
        ResetAllCheckpoints();
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
