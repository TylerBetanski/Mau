using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileScript : MonoBehaviour
{
    [SerializeField] private float waitSeconds = 3.0f;
    [SerializeField] private Transform attackPosition;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask playerLayermask;
    
    private WaitForSeconds wait;
    private WaitForSeconds wait2;
    new private BoxCollider2D collider;

    private bool isWaiting = false;
    private bool isAttacking = false;

    private void Awake()
    {
        wait = new WaitForSeconds(waitSeconds);
        wait2 = new WaitForSeconds(0.75f);
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !(isWaiting || isAttacking))
        {
            StartCoroutine(Attack(collision.gameObject));
        }
    }

    private IEnumerator Attack(GameObject Player)
    {
        isWaiting = true;

        yield return wait;

        if (animator != null)
            animator.SetTrigger("Attack");

        collider.enabled = false;

        Collider2D collision = Physics2D.OverlapCircle(attackPosition.position, 3.5f, playerLayermask);
        if (collision != null && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterController2D>().AddVelocity(new Vector2(0, 15.0f));
        }

        StartCoroutine(AttackCooldown());

        isWaiting = false;
    }

    private IEnumerator AttackCooldown()
    {
        isAttacking = true;
        yield return wait2;
        isAttacking = false;
        collider.enabled = true;
    }

    private void FixedUpdate()
    {
        if(isAttacking)
        {
            Collider2D collision = Physics2D.OverlapCircle(attackPosition.position, 2.5f, playerLayermask);
            if (collision != null && collision.gameObject.tag == "Player") {
                collision.gameObject.GetComponent<PlayerController>().DamageDelay(100, 0.5f);
                isAttacking = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, 2.5f);
    }
}
