using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHiss : MonoBehaviour
{
    private bool _canHiss = true;
    public bool CanHiss { get { return _canHiss; } }
    [SerializeField] private ContactFilter2D filter = new ContactFilter2D();
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool canHitMultiple = true;
    [SerializeField] private Collider2D hiss;

    WaitForSeconds cooldown;
    CatAudioController CA;

    private void Awake()
    {
        cooldown = new WaitForSeconds(cooldownTime);
        CA = GetComponent<CatAudioController>();
        _canHiss = true;
    }

    public void Hiss()
    {
        if (_canHiss)
        {
            // Animate the Hiss
            //
            //
            CA.playSound("Hiss");
            Collider2D[] hitObjects = new Collider2D[10];
            Physics2D.OverlapCollider(hiss, filter, hitObjects);

            foreach (Collider2D collider in hitObjects)
            {
                if (collider != null) { 
                InteractableObject interactableObj = collider.gameObject.GetComponent<InteractableObject>();
                if (interactableObj != null)
                {
                    interactableObj.Interact(gameObject);

                    if (!canHitMultiple)
                        break;
                }
                }
            }

            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canHiss = false;
        yield return cooldown;
        _canHiss = true;
    }
}
