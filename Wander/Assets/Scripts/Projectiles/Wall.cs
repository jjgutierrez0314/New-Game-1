using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float velX = 0.0f;
    public float velY = -0.5f;
    public int damage;
    Animator animator;
    Rigidbody2D rb;// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position;
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            velX = 0f;
            animator.SetTrigger("hits");
            Destroy(gameObject, 1f);
            enemy.Hit(damage);
            //Debug.Log("Enemy Hit");

        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            velX = 0f;
            animator.SetTrigger("hits");
            Destroy(gameObject, 1f);
        }//add enviroment wall interaction
    }


}

