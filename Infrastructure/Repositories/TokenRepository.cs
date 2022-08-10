using Domain.Models.Base;
using Domain.Token;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class TokenRepository : BaseMsSqlRepository<RefreshToken> , ITokenRepository
{
    private readonly UserManager<User> _userManager;
    
    public TokenRepository(BaseMsSqlContext dbContext,UserManager<User> userManager) : base(dbContext)
    {
        _userManager = userManager;
    }

    public RefreshToken AddRefreshToken(RefreshToken token)
    {
        base.Add(token);
        return token;
    }

    public RefreshToken GetRefreshToken(string username, string token)
    {
        return base.Entities.FirstOrDefault(x => x.Email == username && x.Refresh_Token == token && x.IsActive == true);
    }

    public void DeleteUserRefreshTokens(string username, string refreshToken)
    {
        var item = base.Entities.FirstOrDefault(x => x.Email == username && x.Refresh_Token == refreshToken);
        if (item != null) base.Entities.Remove(item);
    }
}