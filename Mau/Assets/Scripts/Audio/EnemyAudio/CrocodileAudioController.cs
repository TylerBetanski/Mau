using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileAudioController : MonoBehaviour
{
    [SerializeField] AudioClip hiss;
    [SerializeField] AudioClip bite;

    private AudioSource AS;
    private void Awake() {
        AS = GetComponent<AudioSource>();
    }
    public void PlayHiss() {
        AS.Stop();
        AS.clip = hiss;
        AS.Play();
    }
    public void PlayBite() {
        AS.Stop();
        AS.clip = bite;
        AS.Play();
    }
}
