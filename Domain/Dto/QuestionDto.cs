using Domain.Interfaces;

namespace Domain.Dto;

public class QuestionDto
{
    public string Text { get; set; }
    public IList<IAnswer> Answers { get; set; }
}