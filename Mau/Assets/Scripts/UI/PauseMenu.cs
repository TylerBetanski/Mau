using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    int numOfHearts;

    [SerializeField] Image[] heartContainers;
    [SerializeField] GameObject ambientLight;
    [SerializeField] AudioSource backgroundSound;
    [SerializeField] AudioClip pauseMenuSound;
    [SerializeField] GameObject brightnessText;
    [SerializeField] Slider slider;

    private AudioClip initialBGM;

    public void UpdateHeartContainers()
    {
        numOfHearts = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getMaxHealth();

        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < numOfHearts)
            {
                heartContainers[i].enabled = true;
            }
            else
            {
                heartContainers[i].enabled = false;
            }
        }
    }

    
    public void UpdateLight()
    {
        string value = slider.value.ToString().Substring(0, 3);

        ambientLight.GetComponent<Light2D>().intensity = slider.value;
        brightnessText.GetComponent<Text>().text = value;
    }

    public void OpenPauseMenu()
    {
        gameObject.SetActive(true);
        initialBGM = backgroundSound.clip;
        backgroundSound.Stop();
        backgroundSound.clip = pauseMenuSound;
        backgroundSound.Play();
    }
    public void ClosePauseMenu()
    {
        gameObject.SetActive(false);
        backgroundSound.Stop();
        backgroundSound.clip = initialBGM;
        backgroundSound.Play();
    }

}
