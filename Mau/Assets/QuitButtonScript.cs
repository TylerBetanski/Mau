using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
