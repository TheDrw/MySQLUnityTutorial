using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    private IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW(GameConstants.BASE_FILE_LOCATION + "register.php", form);
        yield return www;
        if(www.text[0] == '0')
        {
            Debug.Log("User created succesfully with " + www.text);
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)GameConstants.LEVELS.MAIN_MENU);
        }
        else
        {
            Debug.Log("ERR: USER CREATTION FAILED " + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = GameFunctions.VerifyUsernameAndPassword(nameField.text, passwordField.text);
    }
}