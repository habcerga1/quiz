using Domain.Common;
using Domain.Token;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class SolutionResultRepository : BaseMsSqlRepository<UserSolutionResult> , ISolutionResultRepository
{
    public SolutionResultRepository(BaseMsSqlContext dbContext) : base(dbContext)
    {
    }
}