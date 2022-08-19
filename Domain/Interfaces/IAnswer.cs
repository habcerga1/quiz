namespace Domain.Interfaces;

/// <summary>
/// Base interface for Quiz Answers
/// </summary>
public interface IAnswer
{
    string Text { get; set; }
    bool IsCorrect { get; set; }
}