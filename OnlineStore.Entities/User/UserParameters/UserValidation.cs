namespace OnlineStore.Entities.User.UserParameters;

public static class UserValidation
{
    public static bool IsValidLogin(string login)
    {
        if (login.Length < 9) return false;

        return true;
    }

    public static bool IsValidPassword(string password)
    {
        return true;
    }
}