using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    Animator animator;
    PlayerController playerControllerScript;

    BoxCollider2D hitbox;

    public bool attacking = false;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        playerControllerScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            attacking = true;
            animator.SetTrigger("attack");
        }
    }

    void FixedUpdate()
    {

        //if (attacking && animator.GetCurrentAnimatorStateInfo(0).IsName("Warrior_Attack"))
        //{
        //    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        //        attacking = false;
        //}
    }
}
