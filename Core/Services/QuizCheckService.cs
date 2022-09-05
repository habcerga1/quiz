using Domain.Common;
using Domain.Dto;
using Domain.Interfaces;

namespace Core.Services;

public class QuizCheckService
{
    /// <summary>
    /// Equal user answers with correct answer from quiz.
    /// </summary>
    /// <param name="userQuestion"></param>
    /// <param name="dbQuestion"></param>
    /// <returns></returns>
    public bool CheckQuestion(IQuestion userQuestion, IQuestion dbQuestion)
    {
        //Проходим по правильным ответам из БД и сравниваем с тем как ответил пользователь
        //Если хоть один ответ отличаеться то значит пользователь ответил на Вопрос неправильно
        foreach (var answerFromDb in dbQuestion.Answers)
        {
            if (answerFromDb.IsCorrect != userQuestion.Answers.
                    Where(target => target.Text == answerFromDb.Text)
                    .Select(_ => _).First().IsCorrect) 
                return false;
        }
        return true;
    }
    
    /// <summary>
    /// Equal questions and answers
    /// </summary>
    /// <param name="userQuiz">Solved quiz</param>
    /// <param name="dbQuiz">Original quiz</param>
    /// <returns></returns>
    public int CheckSolvedQuiz(QuizDto userQuiz,IQuiz dbQuiz)
    {
        int score = 0;
        foreach (var dbQuestion in dbQuiz.Questions)
        {
            var userQuestion = userQuiz.Questions.Where(t => t.Text == dbQuestion.Text).Select(_ => _).First();
            if (this.CheckQuestion(userQuestion, dbQuestion)) score++;
        }
        return score;
    }
    
}