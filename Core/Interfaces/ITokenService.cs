using Domain.Models.Base;

namespace Core.Interfaces;

public interface ITokenService
{
    string CreateJwtSecurityToken(User user);
}