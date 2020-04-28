using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSFX_Warrior : MonoBehaviour
{

    //Gives easy access to which events are for each one
    [FMODUnity.EventRef]
    public string attackEvent;
    [FMODUnity.EventRef]
    public string move1Event;
    [FMODUnity.EventRef]
    public string move2Event;
    [FMODUnity.EventRef]
    public string move3Event;
    [FMODUnity.EventRef]
    public string footStepEvent;
    [FMODUnity.EventRef]
    public string jumpEvent;
    [FMODUnity.EventRef]
    public string landEvent;

    private FMOD.Studio.EventInstance move3;
    private FMOD.Studio.EventInstance footStep;

    //public functions to be called inside of the animations
    public void attackSound(){
        FMODUnity.RuntimeManager.PlayOneShot(attackEvent);
    }  
    public void move1Sound(){
        FMODUnity.RuntimeManager.PlayOneShot(move1Event);
    }
    public void move2Sound(){
        FMODUnity.RuntimeManager.PlayOneShot(move2Event);
    }
    public void move3SoundStart(){ //starts event and starts the held sound
        move3.start();
        move3.setParameterByName("Shield Hold", 1);

    }
    public void move3SoundStop(){  //releases held sound
        move3.setParameterByName("Shield Hold", 0);
    }
    public void footStepSound(){
        footStep.start();
        //FMODUnity.RuntimeManager.PlayOneShot(footStepEvent);
    }
    public void footstepSoundForest(){
        footStep.setParameterByName("Surface",1);
    }
    public void footstepSoundCave(){
        footStep.setParameterByName("Surface", 0);
    }
    public void jumpSound(){
        FMODUnity.RuntimeManager.PlayOneShot(jumpEvent);
    }
    public void landSound(){
        FMODUnity.RuntimeManager.PlayOneShot(landEvent);
    }
    public void deathSound(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/DeathStinger");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        move3 = FMODUnity.RuntimeManager.CreateInstance(move3Event);
        footStep = FMODUnity.RuntimeManager.CreateInstance(footStepEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
