using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapObject : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 3.0f;

    private bool canBeTriggered = true;

    private WaitForSeconds wait;

    private void Awake()
    {
        wait = new WaitForSeconds(cooldownTime);
        InitializeTrap();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canBeTriggered)
        {
            TriggerTrap(collision.gameObject);
            StartCoroutine(Cooldown());
        }
    }

    protected abstract void TriggerTrap(GameObject obj);
    protected abstract void InitializeTrap();

    private IEnumerator Cooldown()
    {
        canBeTriggered = false;
        yield return wait;
        canBeTriggered = true;
    }


}
