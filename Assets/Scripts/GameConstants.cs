public static class GameConstants
{
    public enum LEVELS { MAIN_MENU = 0, REGISTER_MENU, LOGIN_MENU, GAME, HIGH_SCORES_MENU };
    public const int NAME_MIN_LEN = 3, NAME_MAX_LEN = 16;
    public const int PASSWORD_MIN_LEN = 4, PASSWORD_MAX_LEN = 16;
    public const int MAX_SCORE = 999999;
    public const char DELIMITER = '#';
    public static readonly string BASE_FILE_LOCATION = "http://localhost/sqlconnect/";
}