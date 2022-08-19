using Domain.Common;
using Domain.Dto;
using Domain.Models.Base;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

/// <summary>
/// Base interface for User repository
/// </summary>
public interface IUserRepository: IRepository<User>
{
    Task<ServiceResult> AddUserAsync(User user,string password,CancellationToken cancellationToken);
    
    Task<ServiceResult<LoginResponse>> CheckUserPassword(LoginDto user,string password,CancellationToken cancellationToken);
    Task<User> GetUserAsync(LoginDto user,CancellationToken cancellationToken);
    Task<User> GetUserAsync(string email,CancellationToken cancellationToken);
}