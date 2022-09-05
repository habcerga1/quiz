using Domain.Common;
using Domain.Interfaces.Base;

namespace Domain.Interfaces;

/// <summary>
/// Base interface for Quiz
/// </summary>
public interface IQuiz : IDocument
{
    string AuthorEmail { get; set; }
    string Title { get; set; }
    List<IQuestion> Questions { get; set; }
    bool IsPublic { get; set; }
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
    Int16 Score { get; set; }
    
}