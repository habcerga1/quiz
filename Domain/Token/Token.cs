namespace Domain.Token;

public class Token
{
    public string Access_Token { get; set; }
    public string Refresh_Token { get; set; }
    
    public Token(string accessToken, string refreshToken)
    {
        Access_Token = accessToken;
        Refresh_Token = refreshToken;
    }
}