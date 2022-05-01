using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMoveSound : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Mathf.Abs(rigidBody.velocity.x) > 2)
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
