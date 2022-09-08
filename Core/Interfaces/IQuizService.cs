using System.Security.Claims;
using Domain.Common;
using Domain.Dto;
using Domain.Interfaces;

namespace Core.Interfaces;

public interface IQuizService
{ 
      Task<ServiceResult> AddItemAsync(QuizDto itemDto, CancellationToken cancellationToken);
      Task<ServiceResult> AddSolutionAsync(ClaimsPrincipal user,QuizDto itemDto, CancellationToken cancellationToken);
      Task<ServiceResult> GetItemAsync(string id, CancellationToken cancellationToken);
      Task<ServiceResult> GetItemsByEmailAsync(string email, CancellationToken cancellationToken);
      IQuiz Shuffle(IQuiz item);
}