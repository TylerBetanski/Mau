using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPot : MonoBehaviour
{
    private bool breakingSpeed;
    private void Awake()
    {
        breakingSpeed = false;
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) > 30)
            breakingSpeed = true;

        if (breakingSpeed)
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) < 1.75f)
            {
                breakingSpeed = false;
                Break();
            }
    }

    private void Break()
    {
        GetComponent<AudioSource>().Stop();
        //GetComponent<AudioSource>().time = 0.25f;
        GetComponent<AudioSource>().Play();

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        print(transform.childCount);
        while (transform.childCount > 0) {
            Transform child = transform.GetChild(0);
            print(child.name);
            child.GetComponent<Rigidbody2D>().simulated = true;
            child.GetComponent<Rigidbody2D>().AddForce( (child.position - transform.position).normalized * 75, ForceMode2D.Impulse);
            child.parent = transform.parent;
            child.GetComponent<PotChildScript>().StartFade();
        }
        
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }


}
