using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class DeticatedServer : MonoBehaviour
{
    private void Start()
    {
        if(Application.isBatchMode){
            gameObject.GetComponent<NetworkManager>().StartServer();
        } else {
            gameObject.GetComponent<NetworkManager>().StartClient();
        }
    }

}
