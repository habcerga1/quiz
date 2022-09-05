using Domain.Interfaces.Base;

namespace Domain.Common;

public class ShortQuizDescription : IEntity
{
    public Guid Guid { get; set; }
    public string QuizGuid { get; set; }
    public List<Tag> Tags { get; set; }
    public Category Category { get; set; }
}