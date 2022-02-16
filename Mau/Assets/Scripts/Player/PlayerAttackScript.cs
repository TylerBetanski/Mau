using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField] private Transform attackLocation;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask attackableLayers;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool canHitMultiple = false;

    WaitForSeconds cooldown;

    private bool canAttack = true;

    private void Awake()
    {
        cooldown = new WaitForSeconds(cooldownTime);
    }

    public void Attack()
    {
        if (canAttack)
        {
            // Animate the Attack
            //
            //

            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackLocation.position, attackRadius, attackableLayers);

            foreach (Collider2D collider in hitObjects)
            {
                InteractableObject interactableObj = collider.gameObject.GetComponent<InteractableObject>();
                if (interactableObj != null)
                {
                    interactableObj.Interact();

                    if (!canHitMultiple)
                        break;
                }
            }

            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return cooldown;
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackLocation != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackLocation.position, attackRadius);
        }
    }
}
