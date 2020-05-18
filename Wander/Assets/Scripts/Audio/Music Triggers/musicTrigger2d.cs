using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicTrigger2d : musicTrigger
{


    void OnTriggerEnter2D(Collider2D col)
    {
        base.setMusic();
    }
}
