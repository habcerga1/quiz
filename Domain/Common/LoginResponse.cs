using Domain.Models.Base;

namespace Domain.Common;

public class LoginResponse
{
    public LoginResponse(User user)
    {
        User = user;
    }

    public User User { get; set; }

    public string Token { get; set; }
}