using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Mirror;
public class FireWall : NetworkBehaviour
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
        if(!isLocalPlayer){
            return;
        }
        if (Input.GetButtonDown("Ability3") && !ability3 && Time.time > nextFire)
        {
            count = 0;//resets count
            Timer = 2f;//doesn't work if not here?
            ability3 = true;
            animator.SetTrigger("ability3");
            nextFire = Time.time + fireRate;
            wallPOS = transform.position;
            wallPOS += new Vector2(0.1f, -0.075f);
            active = true;

        }
        Timer -= Time.deltaTime;
        if (active)
        {
            if (count < 3)
            {
                if (Timer <= 0f)
                {
                    CmdFire(wallPOS += new Vector2(0.2f, 0f));
                    Timer = 0.5f;
                }
            }
        }

    }
    [Command]
    void CmdFire(Vector2 adjustPos)
    {
        count += 1;
        GameObject fire = Instantiate(Fire, adjustPos, Quaternion.identity);
        NetworkServer.Spawn(fire);
        Destroy(fire,3f);
        if (count == 0) { active = false; }
    }

    void FixedUpdate()
    {
        if(!isLocalPlayer){
            return;
        }
        if (ability3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability3 = false;
    }
}
