using Domain.Interfaces;

namespace Domain.Common;

public class Answer : IAnswer
{
    public string Text { get; set; }
    
    public bool IsCorrect { get; set; }
}