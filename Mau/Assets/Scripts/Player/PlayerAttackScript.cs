using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    private bool _canAttack = true;
    public bool CanAttack { get { return _canAttack; } }
    [SerializeField] private Transform attackLocation;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask attackableLayers;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool canHitMultiple = false;

    WaitForSeconds cooldown;
    CatAudioController CA;

    private void Awake()
    {
        cooldown = new WaitForSeconds(cooldownTime);
        CA = GetComponent<CatAudioController>();
    }

    public void Attack()
    {
        if (_canAttack)
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
                    if (interactableObj.tag == "Checkpoint")
                        CA.playSound("Purr");
                    
                    interactableObj.Interact(gameObject);

                    if (!canHitMultiple)
                        break;
                }
            }
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
                CA.playSound("Attack");
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return cooldown;
        _canAttack = true;
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
