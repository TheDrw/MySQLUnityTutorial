using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillTextWithHighScores : MonoBehaviour
{
    [SerializeField] private Text[] nameTexts; // max characters ~16 before it can't be shown
    [SerializeField] private Text[] scoreTexts; // max characters ~10

    private void Awake()
    {
        BlankTheText();
    }

    // I have default text to measure out how it looks. 
    // this will erase it, so it won't show on the user side.
    private void BlankTheText()
    {
        foreach (var nameText in nameTexts)
        {
            nameText.text = "";
        }

        foreach (var scoreText in scoreTexts)
        {
            scoreText.text = "";
        }
    }

    public void FillTextWithHighScoreData(List<string> names, List<string> scores)
    {
        for(int i = 0; i < names.Count; i++)
        {
            int rank = i + 1;
            nameTexts[i].text = rank + ": " + names[i];
            scoreTexts[i].text = scores[i];
        }
    }
}
