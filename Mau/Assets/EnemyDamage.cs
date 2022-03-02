using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public bool isKnockedDown = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isKnockedDown) { 
            if (collision.gameObject.tag == "Player") {
                collision.gameObject.GetComponent<PlayerController>().Damage(1);
            }
        }
    }
}
