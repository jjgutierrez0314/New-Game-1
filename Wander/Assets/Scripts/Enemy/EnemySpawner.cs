﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;

    public int numOfEnemies;

    public override void OnStartServer(){
        for(int i = 0; i < numOfEnemies; i++){
            Vector2 spawnPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-8.0f, 8.0f));
            Quaternion spawnRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0);
            GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
