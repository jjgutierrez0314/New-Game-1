using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
public class Player : NetworkBehaviour
{
    private Animator animator;

    private int health;
    private int score = 0;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    // Variables for HP & Stamina bars
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public float maxStamina = 100;
    public float currentStamina;
    public StaminaBar staminaBar;
    public bool dying = false;

    public PlayerController player;
    public LevelChanger levelChanger;

    void Awake()
    {
        animator = GetComponent<Animator>();
        health = 100;
        player = GetComponent<PlayerController>();
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
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

        if (health <= 0)
        {
            dying = true;
            animator.SetTrigger("death");
            levelChanger.FadeToLevel();
        }
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

    public void addScore()
    {
        score += 1;
        if (score >= 1) { levelChanger.FadeToLevel(); }
    }
}
