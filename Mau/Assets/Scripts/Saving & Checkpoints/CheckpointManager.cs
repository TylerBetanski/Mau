using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    [SerializeField] private List<Checkpoint> checkpoints;
    [SerializeField] private int defaultIndex;

    private int currentCheckpointIndex;

    private void Awake()
    {
        CreateInstance();
    }

    public void Reload(GameObject player)
    {
        for(int i = 0; i < checkpoints.Count; i++)
        {
            checkpoints[i].Interact(gameObject);
            if(i == currentCheckpointIndex)
                player.transform.position = checkpoints[i].transform.position;
        }
    }

    private void CreateInstance()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void OnValidate()
    {
        defaultIndex = Mathf.Clamp(defaultIndex, 0, checkpoints.Count - 1);
    }
}
