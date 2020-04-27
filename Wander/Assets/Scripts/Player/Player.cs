using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    // Variables for HP & Stamina bars
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public float maxStamina = 400;
    public float currentStamina;
    public StaminaBar staminaBar;

    void Awake()
    {
        health = 100;
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
            playerRun(1);
            StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Out of stamina");
        }
    }

    public void playerHit(int damage)
    {
        health -= damage;
        Debug.Log("Remaining HP : " + health);

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
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
            currentStamina += 0.5f;
            staminaBar.SetStamina(currentStamina);
            yield return regenTick;
        }
    }
}
