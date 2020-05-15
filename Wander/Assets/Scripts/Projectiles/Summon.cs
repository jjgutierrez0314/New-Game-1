using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Mirror;
public class Summon : NetworkBehaviour
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
        if(!isLocalPlayer){
            return;
        }
        if (Input.GetButtonDown("Ability2"))
        {
            animator.SetTrigger("ability2");
            Summoner();
            
        }
    }
    void Summoner() {
        projectilePOS = transform.position;
        projectilePOS += new Vector2(+0.3f, -0.043f);
        Instantiate(portal, projectilePOS, Quaternion.identity);
    
    }
    void FixedUpdate()
    {
        if(!isLocalPlayer){
            return;
        }
        // Wait for attacking animation to finish
        if (ability2&& animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability2 = false;
    }
}
