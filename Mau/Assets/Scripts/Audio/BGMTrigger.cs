using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTrigger : MonoBehaviour
{
    [SerializeField] AudioClip BGM;
    [SerializeField] AudioSource BGAudioSource;

    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player 1");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player) {
            ChangeBGM();
        }
    }

    private void ChangeBGM() {

        //can use the subroutines to make audio fade in and out

        BGAudioSource.Stop();
        BGAudioSource.clip = BGM;
        BGAudioSource.Play();
    }
}
