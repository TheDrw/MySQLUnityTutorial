using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text playerDisplay;
    public Text scoreDisplay;

    private void Awake()
    {
        if (DBManager.Username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)GameConstants.LEVELS.MAIN_MENU);
            return;
        }

        playerDisplay.text = "Player : " + DBManager.Username;
        scoreDisplay.text = "Score : " + DBManager.Score;
    }

    public void CallSaveData()
    {
        StartCoroutine(CallSaveDataRoutine());
    }

    IEnumerator CallSaveDataRoutine()
    {
        var form = new WWWForm();
        form.AddField("name", DBManager.Username);
        form.AddField("score", DBManager.Score);
        var www = new WWW(GameConstants.BASE_FILE_LOCATION + "savedata.php", form);
        yield return www;

        if(www.text == "0")
        {
            Debug.Log("Game Saved with score: " + DBManager.Score);
        }
        else
        {
            Debug.Log("Save Failed. Err #: " + www.text);
        }
        DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)GameConstants.LEVELS.MAIN_MENU);
    }

    public void IncreaseScore()
    {
        DBManager.Score++;
        scoreDisplay.text = "Score : " + DBManager.Score;
    }
}
