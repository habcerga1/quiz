using Domain.Common;
using Domain.Models.Base;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class UserRepository : BaseMsSqlRepository<User>,IUserRepository
{
    private readonly UserManager<User> _userManager;
    
    public UserRepository(BaseMsSqlContext dbContext,UserManager<User> userManager) : base(dbContext)
    {
        _userManager = userManager;
    }

    public async Task<ServiceResult> AddUserAsync(User user, string password,CancellationToken cancellationToken)
    {
        var item = await _userManager.CreateAsync(user, password);
        if (item.Succeeded)
        {
            var result = await _userManager.FindByEmailAsync(user.Email);
            return ServiceResult.Success(Result.CustomMessage($"[Registration][OK] User: {user.Email} successfully registered e-mail user@domain.com {DateTime.Now}"));
        }
        return ServiceResult.Failed(Result.CustomMessage($"[Registration][Bad] {item.Errors.First().Description} {DateTime.Now}"));
    }
}