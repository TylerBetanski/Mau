using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] Meows;
    [SerializeField] AudioClip Hurt;
    [SerializeField] AudioClip Hiss;
    [SerializeField] AudioClip Purr;
    [SerializeField] float volume;
    [SerializeField] int attackMeowDelay;

    int nextMeowCounter;
    AudioSource AS;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        AS.loop = false;
        AS.volume = volume;
        nextMeowCounter = Random.Range(0, (attackMeowDelay + 1));
    }
    public void playSound(string sound) {

        if (!AS.isPlaying)
        {
            AS.Stop();

            if (sound == "Attack") {
                if (nextMeowCounter <= 0) { 
                    AudioClip meow = Meows[Random.Range(0, Meows.Length)];
                    if (meow != null) {
                        AS.clip = meow;
                        AS.Play();
                    }
                    nextMeowCounter = Random.Range(0, (attackMeowDelay + 1));
                } else
                    nextMeowCounter--;
            }
            else if (sound == "Hurt") {
                AS.clip = Hurt;
                AS.Play();
            }
            else if (sound == "Hiss") {
                AS.clip = Hiss;
                AS.Play();
            }
            else if (sound == "Purr") {
                AS.clip = Purr;
                AS.Play();
            }
        }
    }
}
