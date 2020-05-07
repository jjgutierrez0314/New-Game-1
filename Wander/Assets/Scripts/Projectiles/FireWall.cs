using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public GameObject Fire;
    Vector2 wallPOS;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    Animator animator;
    public bool ability3;
    public float Timer;
    int count = 0;
    bool active = false;
 
    void Awake()
    {

        animator = GetComponentInParent<Animator>();
        ability3 = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Ability3") && !ability3 && Time.time > nextFire)
        {
            count = 0;//resets count
            Timer = 2f;//doesn't work if not here?
            ability3 = true;
            animator.SetTrigger("ability3");
            nextFire = Time.time + fireRate;
            wallPOS = transform.position;
            wallPOS += new Vector2(1.0f, -0.75f);
            active = true;

        }
        Timer -= Time.deltaTime;
        if (active)
        {
            if (count < 3)
            {
                if (Timer <= 0f)
                {

                    fire(wallPOS += new Vector2(2f, 0f));
                    Timer = 0.5f;
                }
            }
        }

    }

    void fire(Vector2 adjustPos)
    {
        count += 1;
        Instantiate(Fire, adjustPos, Quaternion.identity);
        if (count == 0) { active = false; }
    }

    void FixedUpdate()
    {
        if (ability3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability3 = false;
    }
}
