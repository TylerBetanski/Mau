using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabAudioController : MonoBehaviour
{
    [SerializeField] AudioClip buzz;
    [SerializeField] AudioClip scuttle;

    private AudioSource ScarabAS;
    private int soundCountdown;
    private WaitForSeconds soundWait;
    private void Awake()
    {
        ScarabAS = GetComponent<AudioSource>();
        soundWait = new WaitForSeconds(3);
        soundCountdown = Random.Range(1, 7);
        StartCoroutine(ScarabRoutine());
    }

    IEnumerator ScarabRoutine()
    {
        while (true) {
            yield return soundWait;
            if (soundCountdown <= 0)
            {
                PlayBuzz();
                soundCountdown = Random.Range(1, 7);
            }
            else
            {
                soundCountdown--;
            }
            yield return new WaitForSeconds(3f);
            ScarabAS.Stop();
        }
    }

    public void PlayBuzz()
    {
        ScarabAS.Stop();
        ScarabAS.clip = buzz;
        ScarabAS.Play();
    }
    public void PlayScuttle()
    {
        ScarabAS.Stop();
        ScarabAS.clip = scuttle;
        ScarabAS.Play();
    }
}
