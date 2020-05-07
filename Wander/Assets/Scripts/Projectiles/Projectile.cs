using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    Vector2 projectilePOS;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    Animator animator;
    public bool attacking;
    // Start is called before the first frame update

    void Awake()
    {
        animator = GetComponentInParent<Animator>();
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack") && !attacking && Time.time>nextFire)
        {
            attacking = true;
            animator.SetTrigger("attack");
            nextFire = Time.time + fireRate;
            fire();
        }

       
    }
    void fire() {
        projectilePOS = transform.position;
        projectilePOS += new Vector2(+1f,0.5f);
        Instantiate(projectile, projectilePOS, Quaternion.identity);
    }

    void FixedUpdate()
    {
        // Wait for attacking animation to finish
        if (attacking && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            attacking = false;
    }
}
