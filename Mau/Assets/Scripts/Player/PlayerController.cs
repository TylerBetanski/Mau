using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(PlayerAttackScript))]
public class PlayerController : MonoBehaviour { 
    [SerializeField] int maxHealth = 5;
    [SerializeField] float acceleration = 6.0f;
    [SerializeField] float jumpHeight = 3.0f;
    [SerializeField] bool canDoubleJump = true;

    CharacterController2D charController;
    PlayerInputController input;
    PlayerAttackScript attackScript;

    bool secondJump = true;
    int health;

    private void Awake()
    {  
        charController = GetComponent<CharacterController2D>();
        input = GetComponent<PlayerInputController>();
        attackScript = GetComponent<PlayerAttackScript>();

        health = maxHealth;
    }

    private void Die() 
    {
        Debug.Log("I died");
    }

    public void increaseMaxHealth() {
        maxHealth++;
        Debug.Log("Max health is now: " + maxHealth);
    }

    public void enableDoubleJump() {
        canDoubleJump = true;    
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
        } else if (canDoubleJump && secondJump) {
            charController.AddVelocity(new Vector2(0, Mathf.Sqrt(-2 * charController.Gravity * jumpHeight)));
            secondJump = false;
        }
    }

    public void Attack()
    {
        attackScript.Attack();
    }

    private void FixedUpdate()
    {
        if (charController.Grounded) { 
            secondJump = true;
        }

        charController.AddVelocity(new Vector2(input.HorizontalAxis * acceleration, 0)) ;

        if (input.HorizontalAxis != 0) {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(input.HorizontalAxis),
                transform.localScale.y,
                transform.localScale.z);
        }
    }

}
