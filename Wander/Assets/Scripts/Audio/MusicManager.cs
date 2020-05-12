﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private FMOD.Studio.EventInstance musicManager;
    public bool printStateOfMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        musicManager = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Music manager");
        musicManager.start();
        noMusicFullReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (printStateOfMusic){
            float result;
            musicManager.getParameterByName("Music Manager", out result);
            Debug.Log("The music manager param returns: " + result);
            printStateOfMusic = false;
        }
    }
    public void fullParamRest(){ // turns music to silence and resets all params
        musicManager.setParameterByName("Menu Heat", 0);
        musicManager.setParameterByName("Forest Heat", 0);
        musicManager.setParameterByName("Boss Heat", 0);
    }
    public void noMusicFullReset(){ // turns music to silence and resets all params
        musicManager.setParameterByName("Music Manager", 0);
        fullParamRest();
    }
    public void menuMusic(int level){ // sets music to menu and menu heat to parameter  (0 is first loop 1 is second loop)
        musicManager.setParameterByName("Menu Heat", level);
        musicManager.setParameterByName("Music Manager", 1);
    }
    public void caveMusic(){ // sets music to cave
        musicManager.setParameterByName("Music Manager", 2);
    }
    public void forestMusic(int level){ // sets music to forest and forest heat to parameter (0 is first loop 1 is second loop)
        musicManager.setParameterByName("Forest Heat", level);
        musicManager.setParameterByName("Music Manager", 3);
    }
    public void bossMusic(int level){ // sets music to boss and boss heat to parameter (0 is loop1 1 is loop2 and 2 is ending)
        musicManager.setParameterByName("Boss Heat", level);
        musicManager.setParameterByName("Music Manager", 4);
    }
    public void deathMusic(){ // set music to death
        musicManager.setParameterByName("Music Manager", 5);
    }
    public void creditMusic(){ // set music to credit
        musicManager.setParameterByName("Music Manager", 6);
    }
}
