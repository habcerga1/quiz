using Domain.Interfaces;
using MongoDB.Bson;

namespace Domain.Common;

public class Quiz : IQuiz
{
    public ObjectId Id { get; set; }
    string ShortId
    {
        get => Id.ToString();
    }
    public  DateTime CreatedAt { get; }
    public  DateTime UpdatedAt { get; }
    public string AuthorEmail { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<IQuestion> Questions { get; set; }
    public byte MinCorrectPercent { get; set; }
    public bool IsPublic { get; set; }
    public Int16 Score { get; set; }
    public Category Category { get; set; }
}