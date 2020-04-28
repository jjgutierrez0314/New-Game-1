using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;

    private int health;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    // Variables for HP & Stamina bars
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public float maxStamina = 100;
    public float currentStamina;
    public StaminaBar staminaBar;
    public bool dying;

    public PlayerController player;

    void Awake()
    {
        animator = GetComponent<Animator>();
        health = 100;
        player = GetComponent<PlayerController>();
        // cManager = gameObject.GetComponent<ConnectionManager>();
        // msgQueue = gameObject.GetComponent<MessageQueue>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        if (dying && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            // Transition to game over screen
        }
        else if (currentHealth <= 0)
        {
            dying = true;
            animator.SetTrigger("death");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.setTired(false);
            playerRun(0.2f);

            if (regen != null) { StopCoroutine(regen); }
            regen = StartCoroutine(RegenStamina());

            if (currentStamina <= 0)
            {
                player.setTired(true);
                Debug.Log("Out of stamina");
            }
        }
    }

    public void playerHit(int damage)
    {
        health -= damage;
        Debug.Log("Remaining HP : " + health);

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // if (health <= 0)
        // {
        //     SceneManager.GetActiveScene().buildIndex + 1;
        // }
    }

    public void playerRun(float stamina)
    {
        currentStamina -= stamina;
        staminaBar.SetStamina(currentStamina);
    }

    public IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += 1.8f;
            staminaBar.SetStamina(currentStamina);
            yield return regenTick;
        }
        regen = null;
    }

    // IEnumerator Fading()
    // {
    //     anim.SetBool("Fade", true);
    //     yield return new WaitUntil(() => black.color.a == 1);
    //     SceneManager.GetActiveScene().buildIndex + 1;
    // }
}
