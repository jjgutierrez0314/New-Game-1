using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    private int health, maxHealth;
    private int attack, defense;
    public bool isHit, death;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();

        if (GameObject.FindGameObjectWithTag("Bat") != null)
        {
            health = maxHealth = 50;
            attack = 5;
            defense = 3;
        }
        isHit = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.playerHit(5); // Hit for 5 damage
            Debug.Log("Player hit!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (death && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            Destroy(gameObject);
        else if (health <= 0)
        {
            death = true;
            animator.SetBool("dying", death);
        }
    }

    void FixedUpdate()
    {
        if (isHit && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            Debug.Log("ishit is false");
            isHit = false;
            animator.SetBool("isHit", isHit);
        }
    }

    public void hit(int damage)
    {
        health -= damage - defense;
        isHit = true;
        animator.SetBool("isHit", isHit);
        animator.SetTrigger("hit");
    }
}
