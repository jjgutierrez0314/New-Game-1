using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Login : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    public Button loginButton;

    public void CallLogin(){
        StartCoroutine(LoginNow());
    }

    IEnumerator LoginNow(){
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if(www.text[0] == '0'){
            DBManager.username = usernameField.text;
            SceneManager.LoadScene(2);
        } else {
            Debug.Log("User login failed. Error # " + www.text);
        }
    }



    public void VerifyInputs(){
        loginButton.interactable = (usernameField.text.Length >= 8 &&  passwordField.text.Length >= 8);
    }

    public void goToRegister(){
        SceneManager.LoadScene(1);
    }
    
    
}
