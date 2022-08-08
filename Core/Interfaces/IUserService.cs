using Domain.Dto;

namespace Core.Interfaces;

public interface IUserService
{
    Task<bool> AddUserAsync(RegistrationDto user,CancellationToken cancellationToken);
}