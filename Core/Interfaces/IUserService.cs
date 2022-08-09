using Domain.Common;
using Domain.Dto;

namespace Core.Interfaces;

public interface IUserService
{
    Task<ServiceResult> AddUserAsync(RegistrationDto user,CancellationToken cancellationToken);
}