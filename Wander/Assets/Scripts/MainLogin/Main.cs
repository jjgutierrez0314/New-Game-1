﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main : MonoBehaviour
{
    void Awake() {
		DontDestroyOnLoad(gameObject);
		
		gameObject.AddComponent<MessageQueue>();
		gameObject.AddComponent<ConnectionManager>();
		
		NetworkRequestTable.init();
		NetworkResponseTable.init();
		
	}
    void Start () {
		SceneManager.LoadScene ("Login");
		ConnectionManager cManager = gameObject.GetComponent<ConnectionManager>();

		if (cManager) {
			cManager.setupSocket();
			StartCoroutine(RequestHeartbeat(1f));
		}
	}

    // Update is called once per frame
    public IEnumerator RequestHeartbeat(float time) {
		yield return new WaitForSeconds(time);

		ConnectionManager cManager = gameObject.GetComponent<ConnectionManager>();

		if (cManager) {
			RequestHeartbeat request = new RequestHeartbeat();
			request.send();
		
			cManager.send(request);
		}

		StartCoroutine(RequestHeartbeat(1f));
	}

}
