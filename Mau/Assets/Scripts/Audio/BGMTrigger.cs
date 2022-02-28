using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTrigger : MonoBehaviour
{
    [SerializeField] AudioClip BGM;
    [SerializeField] AudioSource BGAudioSource;

    bool changed;
    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player 1");
        changed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((other.gameObject == player) && !changed) {
            ChangeBGM();
            changed = true;
        }
    }

    private void ChangeBGM() {

        //can use the subroutines to make audio fade in and out

        BGAudioSource.Stop();
        BGAudioSource.clip = BGM;
        BGAudioSource.Play();
    }
}
