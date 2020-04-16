using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    Animator animator;

    public bool actionActive;
    public bool ability3, ability3Held;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        actionActive = ability3 = ability3Held = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ability3") && !actionActive)
        {
            actionActive = ability3 = ability3Held = true;
            animator.SetBool("actionActive", actionActive);
            animator.SetTrigger("ability3");
        }

        if (actionActive)
        {
            if (ability3 && !Input.GetButton("Ability3"))
            {
                ability3Held = false;
                animator.SetBool("ability3Held", false);
            }
        }
    }

    void FixedUpdate()
    {
        // Check if animation for first part of ability 3 is done to check if the button is still being held
        if (ability3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            if (ability3Held)
                animator.SetBool("ability3Held", true);
            else
            {
                actionActive = ability3 = false;
                animator.SetBool("actionActive", actionActive);
            }
    }
}
