using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCrystalAudioController : MonoBehaviour
{
    AudioSource crystalAudio;

    private void Awake()
    {
        crystalAudio = GetComponent<AudioSource>();
    }

    public void GoodEnd() {
    
    
    }
}
