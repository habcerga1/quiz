using Domain.Interfaces.Base;

namespace Domain.Interfaces;

public interface IQuizStatistics : IEntity
{
    IQuiz Quiz { get; set; }
    
}