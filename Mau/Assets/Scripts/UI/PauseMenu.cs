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
    [SerializeField] GameObject optionsMenu;
    [SerializeField] AudioSource backgroundSound;
    [SerializeField] AudioClip pauseMenuSound;
    [SerializeField] float volume;

    private AudioClip initialBGM;
    private float initialVolume;

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

    public void OpenPauseMenu()
    {
        gameObject.SetActive(true);
        initialBGM = backgroundSound.clip;
        backgroundSound.Stop();
        initialVolume = backgroundSound.volume;
        backgroundSound.volume = volume;
        backgroundSound.clip = pauseMenuSound;
        backgroundSound.Play();
    }
    public void ClosePauseMenu()
    {
        gameObject.SetActive(false);
        optionsMenu.SetActive(false);
        backgroundSound.Stop();
        backgroundSound.volume = initialVolume;
        backgroundSound.clip = initialBGM;
        backgroundSound.Play();
    }

}
