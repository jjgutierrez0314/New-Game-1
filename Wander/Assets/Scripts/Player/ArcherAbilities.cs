using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Mirror;
public class ArcherAbilities : MonoBehaviour
{
    Animator animator;

    public GameObject Arrowshower, FirstArrow;
    Vector2 showerPOS, arrowPos;
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



    public GameObject RightFire, LeftFire;
    Vector2 projectilePOS;


    Rigidbody2D rb2D;
    public GameObject A1, A2, A3, A4, A5;
    Vector2 projectilePOS3;
    Vector3 velocity = Vector3.zero;
    Vector2 showerPOS3;

    // Start is called before the first frame update
    void Awake()
    {

        animator = GetComponentInParent<Animator>();
        ability1 = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ability1") && !ability1 && Time.time > nextFire1)
        {
            count1 = 0;//resets count
            Timer1 = 2f;//doesn't work if not here?
            ability1 = true;
            animator.SetTrigger("ability1");
            arrowPos = transform.position;

            nextFire1 = Time.time + fireRate1;
            showerPOS = transform.position;
            showerPOS += new Vector2(+0.4f, 0.5f);
            active1 = true;
            Instantiate(FirstArrow, arrowPos, Quaternion.identity);
        }

        if (Input.GetButtonDown("Ability2"))
        {

            animator.SetTrigger("ability2");

            fire2();
        }

        if (Input.GetButtonDown("Ability3"))
        {

            animator.SetTrigger("ability3");

            fire3();
        }






        Timer1 -= Time.deltaTime;
        if (active1)
        {

            if (count1 < 12)
            {
                if (Timer1 <= 0f)
                {

                    fire(showerPOS += new Vector2(FirePosX[count1], FirePosY[count1]));
                    Timer1 = 0.5f;
                }
            }
        }
    }


    void fire(Vector2 adjustPos)
    {

        count1 += 1;
        Instantiate(Arrowshower, adjustPos, Quaternion.identity);
        if (count1 == 0) { active1 = false; }
    }

    void fire2()
    {
        projectilePOS = transform.position;
        projectilePOS += new Vector2(+.1f, 0.05f);
        Instantiate(RightFire, projectilePOS, Quaternion.identity);

    }

    void fire3()
    {
        showerPOS3 = transform.position;
        showerPOS3 += new Vector2(0.3f, 0f);
        Instantiate(A1, showerPOS3, Quaternion.identity);
        showerPOS3 += new Vector2(-0.3f, 0f);
        Instantiate(A2, showerPOS3, Quaternion.identity);
        showerPOS3 += new Vector2(0f, 0.3f);
        Instantiate(A3, showerPOS3, Quaternion.identity);
        showerPOS3 += new Vector2(0f, -0.3f);
        Instantiate(A4, showerPOS3, Quaternion.identity);
        showerPOS3 += new Vector2(-0.3f, 0f);
        Instantiate(A5, showerPOS3, Quaternion.identity);
        /*
        float xMove = 5;
        Vector3 targetVelocity = new Vector2(xMove * 25f * Time.fixedDeltaTime, rb2D.velocity.x);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref velocity, 0.05f);
        */
        //implement rolling forward
    }
    void FixedUpdate()
    {
        // Wait for attacking animation to finish
        if (ability1 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            ability1 = false;
    }
}
