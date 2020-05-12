using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Mirror;
public class FireShower : NetworkBehaviour
{
    public GameObject fireshower;
    
    public Transform firePosition;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    Animator animator;
    public bool ability1;
    public float Timer;
    int count = 0;
    bool active=false;
    float[] FirePosX =
             {0.0f,0.1f,-0.175f,
             0.0f,0.1f,-0.175f,
             0.0f,0.1f,-0.175f,
             0.0f,0.1f,-0.175f};
    float[] FirePosY= 
             {0.0f,0.1f,-0.1f,
             0.0f,0.1f,-0.1f,
             0.0f,0.1f,-0.1f,
             0.0f,0.1f,-0.1f};
    void Awake()
    {

        animator = GetComponentInParent<Animator>();
        ability1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer){
            return;
        }
        if (Input.GetButtonDown("Ability1") && !ability1 && Time.time > nextFire)
        {
            count = 0;//resets count
            Timer = 2f;//doesn't work if not here?
            ability1 = true;
            animator.SetTrigger("ability1");
            nextFire = Time.time + fireRate;
            Vector3 pos = new Vector3(0.4f,0.5f,0);
            firePosition.position += pos;
            active = true;

        }
        Timer -= Time.deltaTime;
        if (active)
        {
            if (count < 12)
            {
                if (Timer <= 0f)
                {
                    Cmdfire(firePosition.position += new Vector3(FirePosX[count], FirePosY[count], 0f));
                    Timer = 0.5f;
                }
            }
        }

    }
    [Command]
    void Cmdfire(Vector2 adjustPos)
    {
        count += 1;
        GameObject fiore = Instantiate(fireshower, adjustPos, Quaternion.identity);
        NetworkServer.Spawn(fiore);
        //showerPOS = transform.position;
        //showerPOS += new Vector2(+4f, 5.0f);
        //Instantiate(fireshower, showerPOS, Quaternion.identity);
        //showerPOS += new Vector2(+1f, 1.0f);
        //Instantiate(fireshower, showerPOS, Quaternion.identity);
        //showerPOS += new Vector2(-2.75f, 0.0f);
        //Instantiate(fireshower, showerPOS, Quaternion.identity);
        Destroy(fiore,3);
        if (count == 0) { active = false; }
    }

    void FixedUpdate()
    {
        if(!isLocalPlayer){
            return;
        }
        // Wait for attacking animation to finish
        if (ability1 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability1 = false;
    }
}

