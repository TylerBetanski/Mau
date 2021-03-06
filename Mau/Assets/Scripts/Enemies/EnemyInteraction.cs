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
        if(CanInteract)
        {
            rb2D.bodyType = RigidbodyType2D.Dynamic;

            if(interactingObject.tag == "Player")
            {
                GetComponent<EnemyDamage>().isKnockedDown = true;
                if (GetComponent<EnemyAttack>())
                    GetComponent<EnemyAttack>().isKnockedDown = true;
                GetComponent<EnemyMovement>().enabled = false;
                Vector3 direction = transform.position - interactingObject.transform.position;
                direction.y = 3.0f;
                direction.Normalize();

                rb2D.AddForce(direction * 500.0f);
                rb2D.AddTorque(500);

                transform.GetComponentInChildren<Animator>().SetBool("Alive", false);
            }
        }
    }
}
