using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public bool ability2;
    Animator animator;
    public GameObject portal;
    Vector2 projectilePOS;
    // Start is called before the first frame update
    void Start()
    {
        ability2 = false;
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ability2"))
        {
            animator.SetTrigger("ability2");
            Summoner();
            
        }
    }
    void Summoner() {
        projectilePOS = transform.position;
        projectilePOS += new Vector2(+1f, -0.43f);
        Instantiate(portal, projectilePOS, Quaternion.identity);
    
    }
    void FixedUpdate()
    {
        // Wait for attacking animation to finish
        if (ability2&& animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability2 = false;
    }
}
