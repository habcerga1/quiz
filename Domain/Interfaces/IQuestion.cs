namespace Domain.Interfaces;

/// <summary>
/// Base interface for Quiz Questions
/// </summary>
public interface IQuestion 
{
    string Text { get; set; }
    IList<IAnswer> Answers { get; set; }
}