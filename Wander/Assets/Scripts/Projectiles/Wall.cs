using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Wall : NetworkBehaviour
{
    public float velX = 0.0f;
    public float velY = -0.5f;
    Rigidbody2D rb;// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
