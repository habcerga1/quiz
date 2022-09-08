using Domain.Interfaces.Base;

namespace Domain.Common;

public class UserSolutionResult : IEntity
{
    public Guid Guid { get; set; }
    public int Id { get; set; }
    public Guid UserGuid { get; set; }
    public string UserEmail { get; set; }
    public string QuizId { get; set; }
    public string QuizTitle { get; set; }
    public int Score { get; set; }

    public UserSolutionResult(Guid guid, Guid userGuid, string userEmail, string quizId,string quizTitle,int score)
    {
        Guid = guid;
        UserGuid = userGuid;
        UserEmail = userEmail;
        QuizId = quizId;
        QuizTitle = quizTitle;
        Score = score;
    }
}