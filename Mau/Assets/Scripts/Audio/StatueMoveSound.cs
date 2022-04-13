using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMoveSound : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
                gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }
    }
}
