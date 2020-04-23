﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb2D;
    private Animator animator;
    Enemy enemy;
    BasicAttack basicAttack;

    public LayerMask ground;
    private Transform groundCheck;

    public float moveSpeed = 16f;
    float xMove = 0f;

    public float jumpVelocity = 7f;
    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 2f;
    Vector3 velocity = Vector3.zero;

    public bool isGrounded;
    public bool facingRight = true;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((xMove > 0 && !facingRight) || (xMove < 0 && facingRight))
            Flip();

        if (enemy.isHit)
            KnockBack();
    }

    void FixedUpdate()
    {
    }

    // Flips the sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void KnockBack()
    {
        float xMove;
        if (facingRight)
            xMove = -50;
        else
            xMove = 50;

        Vector3 targetVelocity = new Vector2(xMove * 25f * Time.fixedDeltaTime, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref velocity, 0.05f);
    }
}
