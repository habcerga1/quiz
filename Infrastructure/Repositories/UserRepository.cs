using Domain.Common;
using Domain.Dto;
using Domain.Models.Base;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

/// <summary>
/// User repository
/// </summary>
public class UserRepository : BaseMsSqlRepository<User>,IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public UserRepository(BaseMsSqlContext dbContext,UserManager<User> userManager,RoleManager<IdentityRole> roleManager) : base(dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<ServiceResult> AddUserAsync(User user, string password,CancellationToken cancellationToken)
    {
        var item = await _userManager.CreateAsync(user, password);
        if (item.Succeeded)
        {
            var result = await _userManager.FindByEmailAsync(user.Email);
            return ServiceResult.Success(Result.CustomMessage($"[Registration][Ok] User: {user.Email} successfully registered Guid: {user.Guid} Time: {DateTime.Now}"));
        }
        return ServiceResult.Failed(Result.CustomMessage($"[Registration][Bad] {item.Errors.First().Description} Time: {DateTime.Now}"));
    }
    
    public async Task<ServiceResult<LoginResponse>> CheckUserPassword(LoginDto model, string password, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null) ServiceResult.Failed(Result.UserNotFound);
        
        var item =  await _userManager.CheckPasswordAsync(user,password);
        return (ServiceResult<LoginResponse>)(item == false
            ? ServiceResult.Failed<LoginResponse>(Result.IncorrectPassword)
            : ServiceResult.Success<LoginResponse>(new LoginResponse(user),Result.SuccessAuthorization));
    }
    
    public async Task<User> GetUserAsync(LoginDto user, CancellationToken cancellationToken)
    {
        return await _userManager.FindByEmailAsync(user.Email);
    }
    
    public async Task<User> GetUserAsync(string email, CancellationToken cancellationToken)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<string> GetUserRole(string email, CancellationToken cancellationToken)
    {
        var result = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(email));
        return result.First();
    }
}