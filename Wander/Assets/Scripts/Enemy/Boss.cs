using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    MusicManager music;
    public int heatUpPoint = 25;
    bool heatUp = false;
    
    void Start(){
        GameObject GO = GameObject.Find("Music");
        music = (MusicManager) GO.GetComponent<MusicManager>();
    }

    void Update(){
        if((getHealth() <= heatUpPoint) && (!heatUp)){
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Character/Monster/Boss/Charge Up", gameObject);   
            music.bossMusic(1);
            heatUp = true;
        }

        if (getHealth() <= 0)
        {
            music.bossMusic(2);
        }
    }
}
