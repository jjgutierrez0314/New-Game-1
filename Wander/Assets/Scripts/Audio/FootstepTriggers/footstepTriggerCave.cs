﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepTriggerCave : MonoBehaviour
{
    private CharacterSFX_Warrior characterSFX_Warrior;

    // Start is called before the first frame update
    void Start()
    {
        characterSFX_Warrior = GameObject.FindObjectOfType<CharacterSFX_Warrior>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        characterSFX_Warrior.footstepSoundCave();
    }
    
}