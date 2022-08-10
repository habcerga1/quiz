using Domain.Models.Base;
using Domain.Token;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public interface ITokenRepository : IRepository<RefreshToken>
{
    RefreshToken AddRefreshToken(RefreshToken user);

    RefreshToken GetRefreshToken(string username, string refreshtoken);

    void DeleteUserRefreshTokens(string username, string refreshToken);

}