using System.Security.Claims;
using Domain.Common;
using Domain.Models.Base;
using Domain.Token;

namespace Core.Interfaces;

public interface ITokenService
{
    ServiceResult<Token> CreateJwtSecurityTokenInstance(User user);
    ServiceResult<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    public string GenerateRefreshToken();
    ServiceResult<Token> GenerateRefreshToken(User username);
}