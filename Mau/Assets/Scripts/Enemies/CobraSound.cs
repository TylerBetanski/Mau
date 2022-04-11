using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobraSound : MonoBehaviour
{

    [SerializeField] AudioClip CobraHiss;
    [SerializeField] AudioClip CobraAttack;

    private AudioSource CobraAS;
    private void Awake()
    {
        CobraAS = GetComponent<AudioSource>();
    }
    public void PlayHiss()
    {
        if (CobraAS.isPlaying)
            CobraAS.Stop();
        CobraAS.clip = CobraHiss;
        CobraAS.Play();
    }
    public void PlayAttack()
    {
        if (CobraAS.isPlaying)
            CobraAS.Stop();
        CobraAS.clip = CobraAttack;
        CobraAS.Play();
    }
}
