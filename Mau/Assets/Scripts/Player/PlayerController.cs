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
    [SerializeField] public bool canHiss = false;
    [SerializeField] public bool canDoubleJump = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Transform playerArt;

    
    GameObject currentDialog;
    CharacterController2D charController;
    PlayerInputController input;
    PlayerAttackScript attackScript;
    PlayerHiss hissScript;
    CatAudioController CA;
    [SerializeField] Animator animator;
    [SerializeField] private float invulnerabilityTime = 0.8f;

    private WaitForSeconds invulnSeconds;

    private bool canBeHurt = true;
    private bool paused = false;
    public bool dialog = false;
    private bool canMove = true;
    bool secondJump = true;
    int health;

    private void Awake()
    {
        CA = GetComponent<CatAudioController>();
        charController = GetComponent<CharacterController2D>();
        input = GetComponent<PlayerInputController>();
        attackScript = GetComponent<PlayerAttackScript>();
        hissScript = GetComponent<PlayerHiss>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        health = maxHealth;

        invulnSeconds = new WaitForSeconds(invulnerabilityTime);
        paused = false;
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

    public void decreaseMaxHealth() {
        maxHealth--;
    }

    public void enableDoubleJump() {
        canDoubleJump = true;    
    }
    public void enableHiss()
    {
        canHiss = true;
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

    public void EnableMovement() {
        canMove = true;
    }

    public void DisableMovement() {
        canMove = false;
        animator.SetBool("Moving", false);
    }

    public void Damage(int amount)
    {
        if (canBeHurt)
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
                StartCoroutine(HurtCooldown());
            }
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

    private IEnumerator HurtCooldown()
    {
        canBeHurt = false;
        yield return invulnSeconds;
        canBeHurt = true;
    }

    public void Jump()
    {
        if (!dialog && canMove)
        {
            if (charController.Grounded)
            {
                charController.AddVelocity(new Vector2(0, Mathf.Sqrt(-2 * charController.Gravity * jumpHeight)));
                animator.SetTrigger("Jump");
            }
            else if (canDoubleJump && secondJump)
            {
                charController.AddVelocity(new Vector2(0, Mathf.Sqrt(-2 * charController.Gravity * jumpHeight)));
                secondJump = false;
                animator.SetTrigger("Jump");
            }
        }
    }

    public void Attack()
    {
        if (!dialog)
        {
            if (animator != null && attackScript.CanAttack)
                animator.SetTrigger("Attacking");

            attackScript.Attack();
        }
    }

    public void Hiss()
    {
        if (!dialog)
        {
            if (canHiss)
            {
                if (animator != null && hissScript.CanHiss)
                    animator.SetTrigger("Hissing");

                hissScript.Hiss();
            }
        }
    }
    public void setDialog(GameObject dialog)
    {
        currentDialog = dialog;
    }
    public void advanceDialog()
    {
        if (currentDialog != null)
            currentDialog.GetComponentInChildren<DialogScript>().updateDialog();
    }
    public void Pause()
    {
        if (!paused)
        {
            pauseMenu.GetComponent<PauseMenu>().UpdateHeartContainers();
            Time.timeScale = 0;
            pauseMenu.GetComponent<PauseMenu>().OpenPauseMenu();
            paused = true;
        }
        else if (paused)
        {
            Time.timeScale = 1;
            pauseMenu.GetComponent<PauseMenu>().ClosePauseMenu();
            paused = false;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (charController.Grounded) {
            secondJump = true;
        }

        if (!dialog && canMove)
        {
            charController.AddVelocity(new Vector2(input.HorizontalAxis * acceleration, 0));
            if (animator != null)
            {
                animator.SetBool("Moving", Mathf.Abs(charController.Velocity.x) >= 0.2f);
            }

            if (input.HorizontalAxis != 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(input.HorizontalAxis),
                    transform.localScale.y,
                    transform.localScale.z);
            }
        }
        animator.SetBool("Grounded", charController.Grounded);
    }

}
