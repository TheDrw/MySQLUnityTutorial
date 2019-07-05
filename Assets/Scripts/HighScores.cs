using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class HighScores : MonoBehaviour
{
    [SerializeField] private FillTextWithHighScores fillTextWithHighScores;

    private List<string> names = new List<string>();
    private List<string> scores = new List<string>();

    private void Start()
    {
        if(fillTextWithHighScores == null)
        {
            fillTextWithHighScores = GetComponentInChildren<FillTextWithHighScores>();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(CallHighScoresRoutine());
    }

    private IEnumerator CallHighScoresRoutine()
    {
        WWW www = new WWW(GameConstants.BASE_FILE_LOCATION + "highscores.php");
        yield return www;
        var scoreSplit = www.text.Split(GameConstants.DELIMITER);

        fillNames(scoreSplit);
        fillScores(scoreSplit);
        showHighScores();
    }

    // len - 1 because there's an extra space in the array.
    // it is from splitting at the delimiter. not sure why, maybe you do.
    private void fillNames(string[] scoreSplit)
    {
        names.Clear();
        for (int i = 0; i < scoreSplit.Length - 1; i += 2)
        {
            names.Add(scoreSplit[i]);
        }
    }

    private void fillScores(string[] scoreSplit)
    {
        scores.Clear();
        for (int i = 1; i < scoreSplit.Length; i += 2)
        {
            scores.Add(scoreSplit[i]);
        }
    }

    private void showHighScores()
    {
        fillTextWithHighScores.FillTextWithHighScoreData(names, scores);
    }

    public void ExitHighScoresMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)GameConstants.LEVELS.MAIN_MENU);
    }
}