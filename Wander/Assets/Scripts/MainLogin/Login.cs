using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;


public class Login : MonoBehaviour
{
    private GameObject mainObject;
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public Button loginButton;
    private string username = "";
	private string password = "";
    private bool isHidden;
	private MessageQueue msgQueue;
	private ConnectionManager cManager;

    
	void Start() {
		mainObject = GameObject.Find("MainObject");
		cManager = mainObject.GetComponent<ConnectionManager>();
		msgQueue = mainObject.GetComponent<MessageQueue> ();
		msgQueue.AddCallback(Constants.SMSG_AUTH, ResponseLogin);
		msgQueue.AddCallback(Constants.SMSG_PLAYERS, responsePlayers);
		msgQueue.AddCallback (Constants.SMSG_TEST, responseTest);
	}

    // public void CallLogin(){
    //     StartCoroutine(LoginNow());
    // }

    // IEnumerator LoginNow(){
    //     WWWForm form = new WWWForm();
    //     form.AddField("name", usernameField.text);
    //     form.AddField("password", passwordField.text);
    //     WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
    //     yield return www;
    //     if(www.text[0] == '0'){
    //         DBManager.username = usernameField.text;
    //         SceneManager.LoadScene(2);
    //     } else {
    //         Debug.Log("User login failed. Error # " + www.text);
    //     }
    // }

    public void Submit() {
        username = usernameField.text;
        password = passwordField.text;
		username = username.Trim();
		password = password.Trim();
		if (username.Length == 0) {
			Debug.Log("User ID Required");
		} else if (password.Length == 0) {
			Debug.Log("Password Required");
		} else {
			cManager.send(requestLogin(username, password));
		}
	}

    public RequestLogin requestLogin(string username, string password) {
		RequestLogin request = new RequestLogin();
		request.send(username, password);
		return request;
	}
	
	public void ResponseLogin(ExtendedEventArgs eventArgs) {
		ResponseLoginEventArgs args = eventArgs as ResponseLoginEventArgs;
		if (args.status == 0) {
			Constants.USER_ID = args.user_id;
			Debug.Log ("Successful Login response : " + args.ToString());
			DBManager.username = username;
			DBManager.id = Constants.USER_ID;
            SceneManager.LoadScene("KeyToContinue");
		} else {
			Debug.Log("Login Failed");
		}
	}
	
	public RequestPlayers requestPlayers() {
		RequestPlayers request = new RequestPlayers();
		request.send ();
		return request;
	}

	public void responsePlayers(ExtendedEventArgs eventArgs) {
		ResponsePlayersEventArgs args = eventArgs as ResponsePlayersEventArgs;
		int numActivePlayers = args.numActivePlayers;
		Debug.Log ("Number of Connected Players : " + numActivePlayers);
	}

		public RequestTest requestTest(string arithmeticOperator, int testNum) {
		RequestTest requestTest = new RequestTest ();
		requestTest.send (arithmeticOperator, testNum);
		return requestTest;
	}
	
	public void responseTest(ExtendedEventArgs eventArgs) {
		ResponseTestEventArgs args = eventArgs as ResponseTestEventArgs;
		Debug.Log ("newTestVar updated on server!!!");
	}

	public void Show() {
		isHidden = false;
	}
	
	public void Hide() {
		isHidden = true;
	}



    // public void VerifyInputs(){
    //     loginButton.interactable = (usernameField.text.Length >= 8 &&  passwordField.text.Length >= 8);
    // }

    public void goToRegister(){
        SceneManager.LoadScene(1);
    }
    
    
}
