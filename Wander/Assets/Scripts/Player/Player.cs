using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;

    void Awake()
    {
        health = 100;
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
