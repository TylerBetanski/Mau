using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : InteractableObject
{
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public override void Interact(GameObject interactingObject)
    {
        rb2D.bodyType = RigidbodyType2D.Dynamic;

        if(interactingObject.tag == "Player")
        {
            Vector3 direction = transform.position - interactingObject.transform.position;
            direction.y = 3.0f;
            direction.Normalize();

            rb2D.AddForce(direction * 500.0f);
        }
    }
}
