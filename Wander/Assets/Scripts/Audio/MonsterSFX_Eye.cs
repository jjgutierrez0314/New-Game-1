using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSFX_Eye : MonoBehaviour
{

     //Gives easy access to which events are for each one
    [FMODUnity.EventRef]
    public string attackEvent;
    [FMODUnity.EventRef]
    public string damageEvent;
    [FMODUnity.EventRef]
    public string deathEvent;
    [FMODUnity.EventRef]
    public string footStepEvent;
    [FMODUnity.EventRef]
    public string emoteEvent;


    //public functions to be called inside of the animations
    public void attackSound(){
        FMODUnity.RuntimeManager.PlayOneShot(attackEvent);
    }  
    public void damageSound(){
        FMODUnity.RuntimeManager.PlayOneShot(damageEvent);
    }
    public void deathSound(){
        FMODUnity.RuntimeManager.PlayOneShot(deathEvent);
    }
    public void footStepSound(){
        FMODUnity.RuntimeManager.PlayOneShot(footStepEvent);
    }
    public void emoteSound(){
        FMODUnity.RuntimeManager.PlayOneShot(emoteEvent);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
