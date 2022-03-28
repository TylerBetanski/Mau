using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    [SerializeField] SpriteRenderer tutorialText;
    [SerializeField] float fadeSpeed;
    [SerializeField] float finalTransparency;

    private bool poppedUp;

    private void Awake()
    {
        poppedUp = false;
        tutorialText.color = new Color(1, 1, 1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!poppedUp)
        {
            poppedUp = true;
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn() {
        float transparency = 0;
        while (transparency <= finalTransparency) { 
            tutorialText.color = new Color(1, 1, 1, transparency);
            yield return new WaitForSeconds(0.1f);
            transparency += fadeSpeed;
        }
        
    }
}
