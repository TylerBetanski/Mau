using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : TrapObject
{
    [SerializeField] private int damage = 1;

    protected override void InitializeTrap()
    {
        
    }

    protected override void TriggerTrap(GameObject obj)
    {
        if(obj.tag == "Player")
        {
            obj.GetComponent<PlayerController>().Damage(damage);
            StartCoroutine(Cooldown());
        }

        if (obj.tag == "Scarab")
        {
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
