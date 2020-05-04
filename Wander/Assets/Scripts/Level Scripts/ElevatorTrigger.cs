﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class ElevatorTrigger : MonoBehaviour
{
    public Elevator platform;
    private bool isColliding;

    private void OnTriggerEnter2D(Collider2D other) {
        // if(Input.GetKey(KeyCode.R)) {
        isColliding = true;
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.R) && isColliding) {
            platform.nextPlatform();
        // }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isColliding = false;
    }
}