public static class GameFunctions
{
    // doesn't really check anything crazy besides the length of the strings.
    public static bool VerifyUsernameAndPassword(string username, string password)
    {
        return (username.Length >= GameConstants.NAME_MIN_LEN && username.Length <= GameConstants.NAME_MAX_LEN) 
            && (password.Length >= GameConstants.PASSWORD_MIN_LEN && password.Length <= GameConstants.PASSWORD_MAX_LEN);
    }
}
