﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    private int health, maxHealth;
    private int attack, defense;
    public bool isHit, death, attacking;
    private float attackCoolDownTime, attackCoolDown;
    private BoxCollider2D hitbox;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();

        if (GameObject.FindGameObjectWithTag("Bat") != null)
        {
            health = maxHealth = 50;
            attack = 5;
            defense = 3;
            attackCoolDown = 2f;
        }
        hitbox = transform.Find("BasicAttack").GetComponent<BoxCollider2D>();
        isHit = death = attacking = hitbox.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.playerHit(5); // Hit for 5 damage
            Debug.Log("Player contacted!");
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
            isHit = false;
            animator.SetBool("isHit", isHit);
        }

        if (attacking && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            attacking = hitbox.enabled = false;
            animator.SetBool("attacking", attacking);
        }
    }

    public void Attack()
    {
        if (attackCoolDownTime <= Time.time)
        {
            attackCoolDownTime = Time.time + attackCoolDown;
            attacking = true;
            animator.SetBool("attacking", attacking);
        }
    }

    public void EnableHitbox()
    {
        hitbox.enabled = true;
    }

    public void Hit(int damage)
    {
        health -= damage - defense;
        isHit = true;
        animator.SetBool("isHit", isHit);
        animator.SetTrigger("hit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.playerHit(attack);
            Debug.Log("Player hit!");
        }
    }
}
