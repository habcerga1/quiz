using Domain.Common;
using Domain.Models.Base;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public interface IUserRepository: IRepository<User>
{
    Task<ServiceResult> AddUserAsync(User user,string password,CancellationToken cancellationToken);
}