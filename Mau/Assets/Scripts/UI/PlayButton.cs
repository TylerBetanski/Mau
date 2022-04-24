using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] public string mainLevel;
    [SerializeField] public string credits;
    [SerializeField] public string artGallery;
    public void Play()
    {
        if (mainLevel != null) { 
            SceneManager.LoadScene(mainLevel);
            Time.timeScale = 1;
        }
    }
    public void Credits()
    {
        if (credits != null)
        {
            SceneManager.LoadScene(credits);
            Time.timeScale = 1;
        }
    }
    public void ArtGallery()
    {
        if (artGallery != null)
        {
            SceneManager.LoadScene(artGallery);
            Time.timeScale = 1;
        }
    }
}