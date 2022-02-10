using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : MonoBehaviour { 
    [SerializeField] int maxHealth = 5;
    [SerializeField] float acceleration = 6.0f;
    [SerializeField] float jumpHeight = 3.0f;

    CharacterController2D charController;
    PlayerInputController input;

    int health;

    private void Awake()
    {  
        charController = GetComponent<CharacterController2D>();
        input = GetComponent<PlayerInputController>();
    }

    private void Die() 
    {
        Debug.Log("I died");
    }

    public void Heal(int amount)
    {
        amount = Mathf.Abs(amount);
        if ((health + amount) > maxHealth)
        {
            health = maxHealth;
        }
        else {
            health += amount;
        }
    }

    public void Damage(int amount)
    {
        amount = Mathf.Abs(amount);
        if ((health - amount) <= 0)
        {
            health = 0;
            Die();
        }
        else
        {
            health -= amount;
        }
    }

    public void Jump()
    {
        if (charController.Grounded) {
            charController.AddVelocity( new Vector2 (0, Mathf.Sqrt(-2 * charController.Gravity * jumpHeight)));
        }
    }

    private void FixedUpdate()
    {
        charController.AddVelocity(new Vector2(input.HorizontalAxis * acceleration, 0)) ;
    }

}
