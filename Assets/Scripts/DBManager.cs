using UnityEngine;

public static class DBManager
{
    public static string Username { get; set; }

    private static int score;
    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = Mathf.Clamp(value, 0, GameConstants.MAX_SCORE);
        }
    }

    public static bool LoggedIn { get { return Username != null; } }

    public static void LogOut()
    {
        Username = null;
    }
}
