using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creates top 5 random high scores for player's table at the start.
// if there aren't 5 scores, it will create it.
// I think the client wouldn't be creating the 5 random people and inserting
// them into the database, but I wanted to practice something.
public class InitialPlayerTable : MonoBehaviour
{
    private void OnEnable()
    {
        // don't really need to do this everytime on the main menu, but ¯\_(ツ)_/¯
        StartCoroutine(InitiatePlayerTableRoutine());
    }

    private IEnumerator InitiatePlayerTableRoutine()
    {
        WWW www = new WWW(GameConstants.BASE_FILE_LOCATION + "checkplayercount.php");
        yield return www;
        Debug.Log(www.text);

        const char initializePlayerTableCodeSuccess = '0';
        if(www.text[0] == initializePlayerTableCodeSuccess)
        {
            InsertTableWithRandoms(); // nested coroutine
        }
    }

    private void InsertTableWithRandoms()
    {
        StartCoroutine(InsertRandomsInTableRoutine());
    }

    private IEnumerator InsertRandomsInTableRoutine()
    {
        WWW www = new WWW(GameConstants.BASE_FILE_LOCATION + "initializeplayertable.php");
        yield return www;
        Debug.Log(www.text);

        const char randomPlayersInsertionSuccess = '0';
        if(www.text[0] != randomPlayersInsertionSuccess)
        {
            Debug.LogError("Random players didn't get inserted in the backend."); // ( ͡° ͜ʖ ͡°)
        }
    }
}
