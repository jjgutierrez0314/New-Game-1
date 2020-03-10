using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Registration : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    // public TMP_InputField confirmField;

    public Button singUpButton;

    public void CallRegister(){
        StartCoroutine(Register());
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
    public void VerifyInputs(){
        singUpButton.interactable = (usernameField.text.Length >= 8 &&  passwordField.text.Length >= 8);
    }
}
