using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] GameObject ambientLight;
    [SerializeField] GameObject brightnessText;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    public void UpdateLight()
    {
        string value = slider.value.ToString().Substring(0, 3);
        
        ambientLight.GetComponent<Light2D>().intensity = slider.value;
        brightnessText.GetComponent<Text>().text = value;
    }

    public void Options() {
        if (gameObject.activeSelf == false)
            gameObject.SetActive(true);
        else 
            gameObject.SetActive(false);
    }
}
