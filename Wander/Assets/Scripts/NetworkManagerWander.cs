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
            chosenClass = DBManager.choosen
        };
        // conn.Send(mess);
        ClientScene.AddPlayer(conn);
        conn.Send(mess);
    }

    void OnCreateCharacter(NetworkConnection conn, ClassMessage message){
        messageGlobal = message.chosenClass;
    }

    public override void OnServerAddPlayer(NetworkConnection conn){
        if(messageGlobal == "Mage"){
            GameObject player = Instantiate(Resources.Load("characters/Mage", typeof(GameObject))) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player);
        } else if (messageGlobal == "Warrior"){
            GameObject player = Instantiate(Resources.Load("characters/Warrior", typeof(GameObject))) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player);
        } else {
            GameObject player = Instantiate(Resources.Load("characters/Mage", typeof(GameObject))) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}