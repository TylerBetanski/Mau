using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] public string mainLevel;
    public void play()
    {
        if (mainLevel != null)  
            SceneManager.LoadScene(mainLevel);
    }
}