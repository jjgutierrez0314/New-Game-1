using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public Elevator platform;
    private void OnTriggerEnter2D(Collider2D other) {
        // if(Input.GetKey(KeyCode.R)) {
            platform.nextPlatform();
        // }
    }
    
}
