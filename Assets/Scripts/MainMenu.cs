using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text playerDisplay;
    public GameObject sunlight; // for a visual cue

    private void OnEnable()
    {
        if(DBManager.LoggedIn)
        {
            sunlight.SetActive(true);
            playerDisplay.text = "Player : " + DBManager.Username;
        }
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene((int)GameConstants.LEVELS.REGISTER_MENU);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene((int)GameConstants.LEVELS.LOGIN_MENU);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene((int)GameConstants.LEVELS.GAME);
    }

    public void GoToHighScoreMenu()
    {
        SceneManager.LoadScene((int)GameConstants.LEVELS.HIGH_SCORES_MENU);
    }
}
