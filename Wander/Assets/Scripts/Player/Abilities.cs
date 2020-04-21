using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    Animator animator;

    public bool actionActive;
    public bool ability1, ability2, ability3, ability3Held;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        actionActive = ability3 = ability3Held = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!actionActive)
        {
            actionActive = true;
            if (Input.GetButtonDown("Ability1"))
            {
                ability1 = true;
                animator.SetTrigger("ability1");
            }
            else if (Input.GetButtonDown("Ability2"))
            {
                ability2 = true;
                animator.SetTrigger("ability2");
            }
            else if (Input.GetButtonDown("Ability3"))
            {
                ability3 = ability3Held = true;
                animator.SetBool("actionActive", actionActive);
                animator.SetTrigger("ability3");
            }
            else
                actionActive = false;
            animator.SetBool("actionActive", actionActive);
        }
        else
        {
            if (ability3 && !Input.GetButton("Ability3"))
            {
                actionActive = ability3 = ability3Held = false;
                animator.SetBool("actionActive", actionActive);
                animator.SetBool("ability3Held", false);
            }
        }
    }

    void FixedUpdate()
    {
        if (ability1 || ability2 || ability3)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                if (ability3Held)
                    animator.SetBool("ability3Held", true);
                else
                {
                    actionActive = ability1 = ability2 = ability3 = false;
                    animator.SetBool("actionActive", actionActive);
                }
            }
        }
    }
}