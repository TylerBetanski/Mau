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
            print("Damaged Player!");
        }
    }
}
