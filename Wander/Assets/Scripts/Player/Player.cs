using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;
    private ConnectionManager cManager;
    private MessageQueue msgQueue;

    void Awake()
    {
        health = 100;
        cManager = gameObject.GetComponent<ConnectionManager>();
        msgQueue = gameObject.GetComponent<MessageQueue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerHit(int damage)
    {
        health -= damage;
        Debug.Log("health : " + health);
    }
}
