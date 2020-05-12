using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class BasicAttackScript : NetworkBehaviour
{
    public float velX = 0.5f;
    public float velY = 0.0f;
    Rigidbody2D rb; // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(!isLocalPlayer){
        //     return;
        // }
        rb.velocity = new Vector2(velX,velY);
        Destroy(gameObject,3f);
    }
}
