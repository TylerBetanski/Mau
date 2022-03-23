using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    int numOfHearts;

    [SerializeField] Image[] heartContainers;

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

}
