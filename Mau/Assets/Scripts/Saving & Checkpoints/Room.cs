using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, ISignalReciever
{
    public Bounds WorldBounds { get { return new Bounds(transform.position + bounds.center, bounds.size); } }

    [SerializeField] private Color roomColor = Color.yellow;
    [SerializeField] private Bounds bounds = new Bounds(Vector3.zero, Vector3.one * 2);

    [SerializeField] private TextBar textBar;
    [SerializeField] private GameObject roomName;

    private SaveObject[] saveObjects;

    private void Awake()
    {
        saveObjects = transform.GetComponentsInChildren<SaveObject>();
    }

    public void ReloadRoom()
    {
        for (int i = 0; i < saveObjects.Length; i++)
        {
            saveObjects[i].ReloadSaveData();
        }
    }

    public void SaveRoom()
    {
        for (int i = 0; i < saveObjects.Length; i++)
        {
            saveObjects[i].OverrideSaveData();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Color gizmosColor = roomColor;
        gizmosColor.a = 0.5f;

        Gizmos.color = gizmosColor;
        Gizmos.DrawCube(transform.position + bounds.center, bounds.size);
    }

    public void RecieveSignal()
    {
        SaveRoom();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textBar.DisplayRoomName(roomName);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        textBar.RemoveRoomName(roomName);
    }
}
