using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button loginButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    private IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW(GameConstants.BASE_FILE_LOCATION + "login.php", form);
        
        yield return www;
        var phpSuccessCode = '0';
        if (www.text[0] == phpSuccessCode)
        {
            var textSplit = www.text.Split(GameConstants.DELIMITER);
            var logCode = textSplit[0];
            var score = int.Parse(textSplit[1]);

            Debug.Log("log code: " + logCode);
            Debug.Log("score: " + score);

            DBManager.Username = nameField.text;
            DBManager.Score = score;

            UnityEngine.SceneManagement.SceneManager.LoadScene((int)GameConstants.LEVELS.MAIN_MENU);
            Debug.Log("Successfully logged in user: " + DBManager.Username);
        }
        else
        {
            Debug.Log("User login failed - err #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        loginButton.interactable = GameFunctions.VerifyUsernameAndPassword(nameField.text, passwordField.text);
    }
}