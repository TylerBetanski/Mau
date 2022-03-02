using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Collect(collision.gameObject.GetComponent<PlayerController>());
            Destroy(this.gameObject);
        } 
    }

    public abstract void Collect(PlayerController PC);
}
