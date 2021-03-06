using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : TrapObject
{
    [SerializeField] private int damage = 1;
    [SerializeField] bool isWater;

    protected override void InitializeTrap()
    {
        
    }

    protected override void TriggerTrap(GameObject obj)
    {
        print(obj.name);
        if(obj.tag == "Player")
        {
            if (isWater)
                obj.GetComponent<CatAudioController>().playSound("Splash");
            obj.GetComponent<PlayerController>().Damage(damage);

            StartCoroutine(Cooldown());
        }

        if (obj.tag == "Scarab")
        {
            obj.transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
