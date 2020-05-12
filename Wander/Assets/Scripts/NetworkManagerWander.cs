using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkManagerWander : NetworkManager {

    public string messageGlobal;
 
    public class ClassMessage : MessageBase {
        public string chosenClass;
    }

    public override void OnStartServer(){
        base.OnStartServer();
        NetworkServer.RegisterHandler<ClassMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect(NetworkConnection conn){
        base.OnClientConnect(conn);
        ClassMessage mess = new ClassMessage{
            chosenClass = "Mage"
        };
        conn.Send(mess);
    }

    void OnCreateCharacter(NetworkConnection conn, ClassMessage message){
        if(message.chosenClass == "Mage"){
            GameObject gameobject = (GameObject)Resources.Load("Mage", typeof(GameObject));
            // NetworkServer.AddPlayerForConnection(conn, gameobject);
            // messageGlobal = message.chosenClass;
        }
    }

    public override void OnServerAddPlayer(NetworkConnection conn){
        if(messageGlobal == "Mage"){
            GameObject player = Instantiate((GameObject)Resources.Load("Warrior", typeof(GameObject)));
            NetworkServer.AddPlayerForConnection(conn, player);
        } else if (messageGlobal == "Warrior"){
            GameObject player = Instantiate((GameObject)Resources.Load("Warrior", typeof(GameObject)));
            NetworkServer.AddPlayerForConnection(conn, player);
        } else {
            GameObject player = Instantiate((GameObject)Resources.Load("Warrior", typeof(GameObject)));
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}