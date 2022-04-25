using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTrigger : MonoBehaviour
{
    [SerializeField] AudioClip beginningBGM;
    [SerializeField] AudioClip laterBGM;
    [SerializeField] bool laterTrigger;
    [SerializeField] AudioSource BGAudioSource;
    [SerializeField] float newVolume;

    GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && laterTrigger){
            ChangeBGM(true);
        }
        else if ((other.gameObject.tag == "Player") && !laterTrigger) {
            ChangeBGM(false);
        }
    }

    private void ChangeBGM(bool isLater) {

        //can use the subroutines to make audio fade in and out

        if (isLater)
        {
            if (BGAudioSource.clip.name == beginningBGM.name)
            {
                Debug.Log("We Gamin");
                BGAudioSource.Stop();
                BGAudioSource.clip = laterBGM;
                BGAudioSource.volume = newVolume;
                BGAudioSource.Play();
            }
        }
        else
        {
            if (BGAudioSource.clip.name == laterBGM.name)
            {
                BGAudioSource.Stop();
                BGAudioSource.clip = beginningBGM;
                BGAudioSource.volume = newVolume;
                BGAudioSource.Play();
            }
        }
    }
}
