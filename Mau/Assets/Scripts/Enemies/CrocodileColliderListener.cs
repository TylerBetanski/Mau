using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileColliderListener : MonoBehaviour
{
    private NewCrocodile crocodileController;

    private void Awake()
    {
        crocodileController = transform.GetComponentInParent<NewCrocodile>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            crocodileController.DetectCollision();
        }
    }

}
