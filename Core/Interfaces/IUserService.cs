using Domain.Common;
using Domain.Dto;
using Domain.Models.Base;
using Domain.Token;

namespace Core.Interfaces;

public interface IUserService
{
    Task<ServiceResult> AddUserAsync(RegistrationDto user,CancellationToken cancellationToken);
    Task<ServiceResult<Token>> LoginAsync(LoginDto user,CancellationToken cancellationToken);
    
    Task<ServiceResult<Token>> RefreshTokenAsync(Token token,CancellationToken cancellationToken);
    
}