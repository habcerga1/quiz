using System.ComponentModel.DataAnnotations;
using Domain.Interfaces.Base;

namespace Domain.Token;

public class RefreshToken : IEntity
{

    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Email { get; set; }
    public string Refresh_Token { get; set; }
    public bool IsActive { get; set; } = true;
    
    public RefreshToken(string refreshToken, string email)
    {
        Refresh_Token = refreshToken;
        Email = email;
        Guid = Guid.NewGuid();
    }

    public RefreshToken()
    {
        
    }
}