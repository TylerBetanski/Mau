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
    [SerializeField] GameObject background;

    private bool isRunning;
    private Vector2 textStartLoc;
    private GameObject currentRoomDisplaying;
    private void Awake()
    {
        isRunning = false;
        background.GetComponent<Image>().enabled = false;
    }
    public void DisplayRoomName(string name)
    {
        foreach (var room in roomNames) {
            if (room.name == name)
            {
                if (isRunning)
                {
                    StopCoroutine(moveIn(currentRoomDisplaying,textEndLoc));
                    StartCoroutine(moveOut(currentRoomDisplaying, textStartLoc));
                }

                if ((currentRoomDisplaying == null) || (room.name != currentRoomDisplaying.name)) {
                    currentRoomDisplaying = room;
                    textStartLoc = new Vector2(room.transform.position.x, room.transform.position.y);
                    StartCoroutine(moveIn(room, textEndLoc));
                }
            }
        }
    }

    public void RemoveRoomName(string name)
    {
        foreach (var room in roomNames)
        {
            if (room.name == name)
            {
                StopCoroutine(moveIn(room, textEndLoc));
                StartCoroutine(moveOut(room,textStartLoc));
            }
        }
    }

    public IEnumerator moveIn(GameObject room, Transform endLoc) {
        background.GetComponent<Image>().enabled = true;
        isRunning = true;
        float rateOfChange = (0.1f * (endLoc.position.x - room.transform.position.x)) / slideTime;

        while (room.transform.position.x < endLoc.position.x)
        {
            room.transform.position = new Vector3(room.transform.position.x + rateOfChange, room.transform.position.y, 0);
            background.transform.position = new Vector3(background.transform.position.x + rateOfChange, background.transform.position.y, 0);
            yield return new WaitForSeconds(0.01f);   
        }
    }

    public IEnumerator moveOut(GameObject room, Vector2 startLoc)
    {
        float rateOfChange = (0.1f * (room.transform.position.x - startLoc.x)) / slideTime;

        while (room.transform.position.x > startLoc.x)
        {
            room.transform.position = new Vector3(room.transform.position.x - rateOfChange, room.transform.position.y, 0);
            background.transform.position = new Vector3(background.transform.position.x - rateOfChange, background.transform.position.y, 0);
            yield return new WaitForSeconds(0.01f);
        }
        background.GetComponent<Image>().enabled = false;
        isRunning = false;
        currentRoomDisplaying = null;
    }
}
