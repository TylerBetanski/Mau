using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightFlicker : MonoBehaviour
{
    [SerializeField] private float maxIntensity = 1.1f;
    [SerializeField] private float minIntensity = 0.9f;
    [SerializeField, Range(0, 100)] private int frequency = 65;

    private new Light2D light;

    private void Awake()
    {
        light = gameObject.GetComponent<Light2D>();
    }

    private void FixedUpdate()
    {
        int randNum = Random.Range(0, 100);

        if(randNum <= frequency)
        {
            float newIntensity = Random.Range(light.intensity - 0.05f, light.intensity + 0.05f);
            newIntensity = Mathf.Clamp(newIntensity, minIntensity, maxIntensity);
            light.intensity = newIntensity;
        }
    }
}
