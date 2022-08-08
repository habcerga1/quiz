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

    public async Task<bool> AddUserAsync(User user, string password,CancellationToken cancellationToken)
    {
        var userCreated = await _userManager.CreateAsync(user, password);
        var userFromDb = await _userManager.FindByEmailAsync(user.Email);
        return userFromDb != null ? true : false;
    }
}