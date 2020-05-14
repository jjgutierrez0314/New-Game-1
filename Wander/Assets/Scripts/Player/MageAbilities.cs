using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Mirror;

//Ability 3 is bugged where it won't activate after a while
public class MageAbilities : MonoBehaviour
{
    public Animator animator;

    public GameObject fireshower;
    Vector2 showerPOS;
    public float fireRate1 = 0.5f;
    float nextFire1 = 0.0f;
    public bool ability1;
    public float Timer1;
    int count1 = 0;
    bool active1 = false;
    float[] FirePosX =
             {0.0f,0.1f,-0.175f,
             0.0f,0.1f,-0.175f,
             0.0f,0.1f,-0.175f,
             0.0f,0.1f,-0.175f};
    float[] FirePosY =
             {0.0f,0.1f,-0.1f,
             0.0f,0.1f,-0.1f,
             0.0f,0.1f,-0.1f,
             0.0f,0.1f,-0.1f};


    public bool ability2;
    public Animator animatorMin;
    public GameObject portal, minion;
    Vector2 projectilePOS;
    Vector2 minionPOS;

    public GameObject Fire;
    Vector2 wallPOS;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    //public Animator Wallanimator;
    public bool ability3;
    public float Timer;
    int count = 0;
    bool active = false;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        ability1 = ability2 = ability3 = false;
         
        animatorMin = GetComponentInParent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    { 
            if (Input.GetButtonDown("Ability1") && !ability1 && Time.time > nextFire1)
        {

            ability1 = true;
            animator.SetTrigger("ability1");
            nextFire1 = Time.time + fireRate;
            showerPOS = transform.position;
            showerPOS += new Vector2(+0.4f, 0.5f);
            fire1(showerPOS);
            
        }
            else if (Input.GetButtonDown("Ability2"))
            {
            animator.SetTrigger("ability2");
            Summoner();
        }
            else if (Input.GetButtonDown("Ability3") && Time.time > nextFire)
            {
           
            ability3 = true;
            animator.SetTrigger("ability3");
            nextFire = Time.time + fireRate;
            wallPOS = transform.position;
            Instantiate(Fire, wallPOS, Quaternion.identity);

        }



      

    }
       
     
    void FixedUpdate()
    {
        if (ability1 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability1 = false;


        // Wait for attacking animation to finish
        if (ability2 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability2 = false;


        if (ability3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability3 = false;
    }
    void fire1(Vector2 adjustPos)
    {
        //count += 1;
        Instantiate(fireshower, adjustPos, Quaternion.identity);

       // if (count == 0) { active = false; }
    }


    void Summoner()
    {
        projectilePOS = transform.position;
        projectilePOS += new Vector2(+0.3f, -0.043f);
        Instantiate(portal, projectilePOS, Quaternion.identity);
        minionPOS = transform.position;
        minionPOS += new Vector2(+0.3f, -0.043f);
        Instantiate(minion, minionPOS, Quaternion.identity);


    }

    



}