using Domain.Common;
using Domain.Dto;
using Domain.Models.Base;

namespace Core.Interfaces;

public interface IUserService
{
    Task<ServiceResult> AddUserAsync(RegistrationDto user,CancellationToken cancellationToken);
    Task<string> LoginAsync(LoginDto user,CancellationToken cancellationToken);
    
}