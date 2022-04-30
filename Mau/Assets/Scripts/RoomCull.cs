using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCull : MonoBehaviour
{
    [SerializeField] private GameObject room;

    private bool isDisabling = false;

    private WaitForSeconds delay;

    private void Awake() {
        if (room == null)
            room = transform.GetChild(0).gameObject;

        delay = new WaitForSeconds(10);

        room.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            room.SetActive(true);
            if (isDisabling)
                isDisabling = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            if (room.activeInHierarchy && !isDisabling)
                StartCoroutine(disableRoom());
        }
    }

    IEnumerator disableRoom() {
        isDisabling = true;


        yield return delay;

        if (isDisabling)
            room.SetActive(false);
        isDisabling = false;
        StopAllCoroutines();
    }
}
