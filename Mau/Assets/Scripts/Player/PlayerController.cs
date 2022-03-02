using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(PlayerAttackScript))]
public class PlayerController : MonoBehaviour {
    [SerializeField] int maxHealth;
    [SerializeField] float acceleration = 6.0f;
    [SerializeField] float jumpHeight = 3.0f;
    [SerializeField] bool canDoubleJump = true;

    CharacterController2D charController;
    PlayerInputController input;
    PlayerAttackScript attackScript;
    CatAudioController CA;
    [SerializeField] Animator animator;

    bool secondJump = true;
    int health;

    private void Awake()
    {
        CA = GetComponent<CatAudioController>();
        charController = GetComponent<CharacterController2D>();
        input = GetComponent<PlayerInputController>();
        attackScript = GetComponent<PlayerAttackScript>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        health = maxHealth;
    }

    private void Die() 
    {
        FindObjectOfType<CheckpointManager>().ReloadWorld(gameObject);
        health = maxHealth;
    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public int getHealth()
    {
        return health;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void increaseMaxHealth() {
        maxHealth++;
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
        CA.playSound("Hurt");
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

    public void DamageDelay(int amount, float time)
    {
        StartCoroutine(DelayDamage(amount, time));
    }

    private IEnumerator DelayDamage(int amount, float time)
    {
        yield return new WaitForSeconds(time);
        Damage(amount);
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
        if (animator != null && attackScript.CanAttack)
            animator.SetTrigger("Attacking");

        attackScript.Attack();
    }

    private void FixedUpdate()
    {
        if (charController.Grounded) { 
            secondJump = true;
        }

        charController.AddVelocity(new Vector2(input.HorizontalAxis * acceleration, 0));
        if (animator != null)
            animator.SetBool("Moving", charController.Velocity.x != 0);

        if (input.HorizontalAxis != 0) {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(input.HorizontalAxis),
                transform.localScale.y,
                transform.localScale.z);
        }
    }

}
