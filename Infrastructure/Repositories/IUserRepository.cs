using Domain.Models.Base;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public interface IUserRepository: IRepository<User>
{
    Task<bool> AddUserAsync(User user,string password,CancellationToken cancellationToken);
}