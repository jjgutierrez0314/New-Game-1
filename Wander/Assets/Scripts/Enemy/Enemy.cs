using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public bool isHit;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
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

    public void hit()
    {
        isHit = true;
        animator.SetBool("isHit", isHit);
        animator.SetTrigger("hit");
    }
}
