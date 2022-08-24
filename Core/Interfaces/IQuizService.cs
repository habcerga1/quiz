using Domain.Common;
using Domain.Dto;
using Domain.Interfaces;

namespace Core.Interfaces;

public interface IQuizService
{ 
      Task<ServiceResult> AddItem(QuizDto itemDto, CancellationToken cancellationToken);
      Task<ServiceResult> GetItem(string id, CancellationToken cancellationToken);
      public IQuiz Shuffle(IQuiz item);
}