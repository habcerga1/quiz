using System.Security.Claims;
using Domain.Models.Base;
using Domain.Token;

namespace Core.Interfaces;

public interface ITokenService
{
    string CreateJwtSecurityToken(User user);
    Token CreateJwtSecurityTokenInstance(User user);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    public string GenerateRefreshToken();
    public Token GenerateRefreshToken(User username);
}