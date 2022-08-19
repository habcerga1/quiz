using Domain.Interfaces;

namespace Domain.Dto;

public class AnswerDto : IAnswer
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}