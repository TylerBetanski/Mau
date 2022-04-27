using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotChildScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartFade() {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(5f);
        while (spriteRenderer.color.a > 0) {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            Color c = spriteRenderer.color;
            c.a -= 0.01f;
            spriteRenderer.color = c;
        }
        Destroy(gameObject);
    }
    
}
