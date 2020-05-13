using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    public float velX = 0.0f;
    Animator animator;
    CircleCollider2D hitbox;
    public float velY = -0.5f;
    Rigidbody2D rb;// Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX,velY);
        Destroy(gameObject, 5f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("hits");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            velX =velY= 0f;
          
            Destroy(gameObject, 1f);
            enemy.Hit(1); // Hit for 5 damage
            Debug.Log("Enemy Hit");

        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("hits");
            velX = velY = 0f;
       
            Destroy(gameObject, 1f);
        }//add enviroment wall interaction
    }
}

