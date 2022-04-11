using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Collider2D attackCollider;
    [SerializeField] float attackTiming;
    [SerializeField] float pissedDelay;
    [SerializeField] private ContactFilter2D filter = new ContactFilter2D();
    [SerializeField] private bool isCobra;
    private bool attacking = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !attacking) {
            attacking = true;
            StartCoroutine(Damage(collision.gameObject));
        }
    }


    private IEnumerator Damage(GameObject player) {
        if (isCobra)
            gameObject.GetComponent<CobraSound>().PlayHiss();
        yield return new WaitForSeconds(pissedDelay);
        gameObject.GetComponentInChildren<Animator>().SetTrigger("Attack");
        yield return new WaitForSeconds(attackTiming);
        Collider2D[] hitObjects = new Collider2D[10];
        Physics2D.OverlapCollider(attackCollider, filter, hitObjects);
        foreach (Collider2D collider in hitObjects)
        {
            if (collider != null)
            {
                if (collider.gameObject.tag == "Player")
                {
                    player.GetComponent<PlayerController>().Damage(damage);
                }
            }
        }
        if (isCobra)
            gameObject.GetComponent<CobraSound>().PlayAttack();
        yield return new WaitForSeconds(0.6f);

        attacking = false;
    }

}
