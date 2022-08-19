using Domain.Common;

namespace Core.Interfaces;

public interface IQuizService
{
    Task<ServiceResult> AddItem(CancellationToken cancellationToken);
    Task<ServiceResult> GetItem(CancellationToken cancellationToken);
    Task<ServiceResult> GetItems(CancellationToken cancellationToken);
    Task<ServiceResult> Solve(CancellationToken cancellationToken);
}