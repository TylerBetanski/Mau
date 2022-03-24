using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBar : MonoBehaviour
{
    [SerializeField] GameObject[] roomNames;
    [SerializeField] float duration;
    [SerializeField] float slideTime;
    [SerializeField] Transform textEndLoc;

    private bool isRunning;
    private Vector2 textStartLoc;
    private GameObject currentRoomDisplaying;
    private void Awake()
    {
        isRunning = false;
    }
    public void DisplayRoomName(GameObject room)
    {
        foreach (var roomFromList in roomNames) {
            if (roomFromList == room)
            {
                if (isRunning)
                {
                    StopCoroutine(MoveIn(currentRoomDisplaying,textEndLoc));
                    StartCoroutine(MoveOut(currentRoomDisplaying, textStartLoc));
                }

                if ((currentRoomDisplaying == null) || (roomFromList != currentRoomDisplaying)) {
                    currentRoomDisplaying = roomFromList;
                    textStartLoc = new Vector2(roomFromList.transform.position.x, roomFromList.transform.position.y);
                    StartCoroutine(MoveIn(roomFromList, textEndLoc));
                }
            }
        }
    }

    public void RemoveRoomName(GameObject room)
    {
        foreach (var roomFromList in roomNames)
        {
            if (roomFromList == room)
            {
                StopCoroutine(MoveIn(roomFromList, textEndLoc));
                StartCoroutine(MoveOut(roomFromList, textStartLoc));
            }
        }
    }

    public IEnumerator MoveIn(GameObject room, Transform endLoc) {
        isRunning = true;
        float rateOfChange = (0.1f * (endLoc.position.x - room.transform.position.x)) / slideTime;

        while (room.transform.position.x < endLoc.position.x)
        {
            room.transform.position = new Vector3(room.transform.position.x + rateOfChange, room.transform.position.y, 0);
            yield return new WaitForSeconds(0.01f);   
        }
    }

    public IEnumerator MoveOut(GameObject room, Vector2 startLoc)
    {
        float rateOfChange = (0.1f * (room.transform.position.x - startLoc.x)) / slideTime;

        while (room.transform.position.x > startLoc.x)
        {
            room.transform.position = new Vector3(room.transform.position.x - rateOfChange, room.transform.position.y, 0);
            yield return new WaitForSeconds(0.01f);
        }
        isRunning = false;
        currentRoomDisplaying = null;
    }
}
