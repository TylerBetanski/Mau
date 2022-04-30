using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ColorAnimate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    new Light2D light;

    public List<Color> targetColors;
    public float transitionTime;

    public Vector3 colorInfo;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        light = GetComponent<Light2D>();
    }

    private IEnumerator TransitionToColor(int index) {
        float currentTime = 0;
        Color oldColor = spriteRenderer.color;
        while(currentTime < transitionTime) {
            yield return new WaitForSeconds(Time.deltaTime);
            Color newCol = Color.Lerp(oldColor, targetColors[index], currentTime/transitionTime);
            spriteRenderer.color = newCol;
            light.color = newCol;
            currentTime += Time.deltaTime;
            colorInfo = new Vector3(newCol.r, newCol.g, newCol.b);
        }

        if (index < targetColors.Count - 1) {
            StartCoroutine(TransitionToColor(index + 1));
        } else {
            StartCoroutine(TransitionToColor(0));
        }
    }

    private void OnEnable() {
        if (targetColors != null && targetColors.Count > 0) {
            spriteRenderer.color = targetColors[0];
            light.color = targetColors[0];
        }
        StartCoroutine(TransitionToColor(1));
    }
}
