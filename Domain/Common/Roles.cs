namespace Domain.Common;

public static class Roles
{
    public const string User = "User";
    public const string Subscriber = "Subscriber";
    public const string Administrator = "Administrator";
    
    public const string AutorizedPostNewQuizzes = $"{Subscriber},{Administrator}";
    public const string AutorizedUsers = $"{User},{Subscriber},{Administrator}";
}