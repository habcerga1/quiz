using Domain.Interfaces.Base;

namespace Domain.Interfaces;

public interface IAttachedUsersToQuiz 
{
    IList<IUserShortInfo> UsersList { get; set; }
}