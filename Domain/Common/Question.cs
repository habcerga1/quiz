using Domain.Interfaces;

namespace Domain.Common;

public class Question : IQuestion
{
    public string Text { get; set; }
    public IList<IAnswer> Answers { get; set; }
    
    public int CorrectAnswers { get; set; }
}