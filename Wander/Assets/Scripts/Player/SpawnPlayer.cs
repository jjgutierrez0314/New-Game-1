using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{   
    private GameObject mainObject;
    public GameObject warriorPrefab;

    private string username;
    private int id;
    public Transform location;
    private MessageQueue msgQueue;
	private ConnectionManager cManager;

    bool once = true;
    public void spawnWarrior(){
        location = GameObject.Find("spawner").transform;
        GameObject warrior = Instantiate(warriorPrefab, location, true) as GameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        mainObject = GameObject.Find("MainObject");
		cManager = mainObject.GetComponent<ConnectionManager>();
		msgQueue = mainObject.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_SPAWN, ResponseSpawn);
        username = DBManager.username;
        id = DBManager.id;;
    }

    // Update is called once per frame
    void Update()
    {
        if(once){
            cManager.send(requestSpawn(username,id));
            once = false;
        }
    }
    public void ResponseSpawn(ExtendedEventArgs eventArgs){
        ResponseSpawnEventArgs args = eventArgs as ResponseSpawnEventArgs;
        if(args.status == 0){
            Debug.Log("Player has been succesfully spawned");
            spawnWarrior();
        }
    }
    public RequestSpawn requestSpawn(string username, int id){
        RequestSpawn request = new RequestSpawn();
        request.send(username,id);;
        return request;
    }
}
