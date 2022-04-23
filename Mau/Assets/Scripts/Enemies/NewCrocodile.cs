using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCrocodile : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius = 8;
    [SerializeField] private LayerMask playerLayers;

    private Animator animator;
    private CrocodileAudioController CAC;

    private bool isTriggered = false;
    
    private WaitForSeconds angryWait;
    private WaitForSeconds attackWait;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        CAC = GetComponent<CrocodileAudioController>();
        angryWait = new WaitForSeconds(2);
        attackWait = new WaitForSeconds(1.33f);
    }

    private void OnEnable() {
        isTriggered = false;
    }

    public void DetectCollision()
    {
        if (!isTriggered)
        {
            animator.SetTrigger("Angry");
            StartCoroutine(CrocodileRoutine());
            isTriggered = true;
        }
    }

    IEnumerator CrocodileRoutine()
    {   
        CAC.PlayHiss();
        yield return angryWait;
        
        animator.SetTrigger("Attack");

        Collider2D playerCollider = Physics2D.OverlapCircle(attackPoint.position, attackRadius, playerLayers);
        if (playerCollider != null)
        {

            GameObject player = playerCollider.gameObject;
            player.GetComponent<CharacterController2D>().AddVelocity(new Vector2(0, 14));
            player.GetComponent<PlayerController>().DamageDelay(100, 1.2f);

            yield return attackWait;
            CAC.PlayBite();
            player.GetComponent<CatAudioController>().playSound("Splash");
        }
        isTriggered = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
