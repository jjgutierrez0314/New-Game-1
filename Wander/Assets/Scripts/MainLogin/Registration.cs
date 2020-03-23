﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Registration : MonoBehaviour
{   
    private GameObject mainObject;
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TMP_InputField confirmedPasswordField;
    private string username = "";
	private string password = "";
	private string confirmedPassword = "";

    private MessageQueue msgQueue;
	private ConnectionManager cManager;
    // public TMP_InputField confirmField;

    public Button singUpButton;
    
    void Start() {
		mainObject = GameObject.Find("MainObject");
		cManager = mainObject.GetComponent<ConnectionManager>();
		msgQueue = mainObject.GetComponent<MessageQueue> ();
		msgQueue.AddCallback(Constants.SMSG_REG, ResponseRegistration);
	}
    
    IEnumerator Register(){
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0"){
            Debug.Log("User Created successfully");
            SceneManager.LoadScene(0);
        } else {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }

    public void Submit(){
        username = usernameField.text;
        password = passwordField.text;
        confirmedPassword = confirmedPasswordField.text;
		username = username.Trim();
		password = password.Trim();
        confirmedPassword = confirmedPassword.Trim();
        if(username.Length == 0){
            Debug.Log("User ID Required");
        } else if (password.Length == 0 || confirmedPassword.Length == 0){
            Debug.Log("Password Required");
        } else {
            cManager.send(requestRegistration(username, password, confirmedPassword));
        }
    }

    public void goToLogin(){
        SceneManager.LoadScene("Login");
    }

    public void ResponseRegistration(ExtendedEventArgs eventArgs) {
		ResponseLoginEventArgs args = eventArgs as ResponseLoginEventArgs;
		if (args.status == 0) {
			Constants.USER_ID = args.user_id;
			Debug.Log ("Successful Registration response : " + args.ToString());
            SceneManager.LoadScene("Login");
		} else {
			Debug.Log("Registration Failed");
		}
	}

    public RequestRegistration requestRegistration(string username, string password, string confirmedPassword){
        RequestRegistration request = new RequestRegistration();
        request.send(username,password,confirmedPassword);
        return request;
    }
}
