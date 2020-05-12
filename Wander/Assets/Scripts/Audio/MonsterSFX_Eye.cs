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
    public string emoteEvent;

    public GameObject gameobject;



    //public functions to be called inside of the animations
    public void attackSound(){
        FMODUnity.RuntimeManager.PlayOneShotAttached(attackEvent, gameobject);
    }  
    public void damageSound(){
        FMODUnity.RuntimeManager.PlayOneShotAttached(damageEvent, gameobject);
    }
    public void deathSound(){
        FMODUnity.RuntimeManager.PlayOneShotAttached(deathEvent, gameobject);
    }
    public void emoteSound(){
        FMODUnity.RuntimeManager.PlayOneShotAttached(emoteEvent, gameobject);
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
