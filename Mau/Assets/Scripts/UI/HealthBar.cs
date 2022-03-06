using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    int health;
    int numOfHearts;

    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    private void FixedUpdate() {

        health = GameObject.Find("Player 1").GetComponent<PlayerController>().getHealth();
        numOfHearts = GameObject.Find("Player 1").GetComponent<PlayerController>().getMaxHealth();

        if (health > numOfHearts) {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else { 
            hearts[i].enabled = false;
            }
        }
    }
}
