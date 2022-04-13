using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMoveSound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }


    /*private void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }*/



}
