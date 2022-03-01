using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAudioController : MonoBehaviour
{
    [SerializeField] AudioClip Attack;
    [SerializeField] AudioClip Hurt;
    [SerializeField] AudioClip Meow;
    [SerializeField] AudioClip Hiss;
    [SerializeField] AudioClip Purr;
    [SerializeField] float volume;

    AudioSource AS;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        AS.loop = false;
        AS.volume = volume;
    }
    public void playSound(string sound) {

        if (!AS.isPlaying)
        {
            AS.Stop();

            if (sound == "Attack") {
                AS.clip = Attack;
            }
            if (sound == "Hurt") {
                AS.clip = Hurt;
            }
            if (sound == "Meow") {
                AS.clip = Meow;
            }
            if (sound == "Hiss") {
                AS.clip = Hiss;
            }
            if (sound == "Purr") {
                AS.clip = Purr;
            }

            AS.Play();
        }
    }
}
