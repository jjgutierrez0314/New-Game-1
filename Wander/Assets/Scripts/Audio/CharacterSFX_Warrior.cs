using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSFX_Warrior : MonoBehaviour
{
    public bool printFootstep = false;

    //Gives easy access to which events are for each one

    [FMODUnity.EventRef]
    public string move1Event;

    private float distance = 0.2f;
    private int Material= 1;


    private FMOD.Studio.EventInstance move3;

    private FMOD.Studio.EventInstance landing;

    //public functions to be called inside of the animations
    public void attackSound(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Warrior/Basic Attack");
    }  
    public void move1Sound(){
        FMODUnity.RuntimeManager.PlayOneShot(move1Event);
    }
    public void move2Sound(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Warrior/Move2");
    }
    public void move3SoundStart(){ //starts event and starts the held sound
        move3.start();
        move3.setParameterByName("Shield Hold", 1);

    }
    public void move3SoundStop(){  //releases held sound
        move3.setParameterByName("Shield Hold", 0);
    }
    public void footStepSound(){
        FMOD.Studio.EventInstance footStep = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Footsteps");
        footStep.setParameterByName("Surface", Material);
        footStep.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, GetComponent<Rigidbody>()));
        footStep.start();
        if (printFootstep){
            float result;
            footStep.getParameterByName("Surface", out result);
            Debug.Log("The footstep surface param returns: " + result);
            printFootstep = false;
        }
        footStep.release();
        //Debug.Log("The footstep surface param returns: " + Material);
    }

    public void jumpSound(){
        FMOD.Studio.EventInstance jump = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Jump");
        jump.setParameterByName("Surface", Material);
        jump.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, GetComponent<Rigidbody>()));
        jump.start();
        jump.release();
    }
    public void landSound(){
        FMOD.Studio.EventInstance land = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Landing");
        land.setParameterByName("Surface", Material);
        land.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, GetComponent<Rigidbody>()));
        land.start();
        land.release();
    }
    public void deathSound(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/Music/DeathStinger");
    }
    

    void MaterialCheck() // checks what material before footstep
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, distance, 1 << 8);

        if (hit.collider)
        {
            if (hit.collider.tag == "Material: Cave")
                Material = 0;
            else if (hit.collider.tag == "Material: Grass")
                Material = 1;
            else
                Material = 1;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        move3 = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Warrior/Move3");
        //footStep = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Footsteps");
        
    }

void FixedUpdate()
    {
        MaterialCheck();
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.blue);
    }
    // Update is called once per frame
    void Update()
    {

    }
}



