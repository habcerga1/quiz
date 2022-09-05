using Core.Interfaces;
using Core.Services;
using Domain.Common;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Microsoft.Extensions.Logging;
using Moq;
using TestData;

namespace UnitTests;

public class QuizCheckerServiceTest
{
    private TestQuiz _data;
    private Mock<ILogger<UserService>> _mockLogger = new Mock<ILogger<UserService>>();
    private Mock<IMongoRepository<Quiz>> _mockRepository = new Mock<IMongoRepository<Quiz>>();
    private Mock<ISolutionResultRepository> _mockSolutionRepository = new Mock<ISolutionResultRepository>();
    private QuizCheckService _quizCheckService;
    private IQuizService _quizService;
    
    [SetUp]
    public void Setup()
    {
        _data = new TestQuiz();
        _quizCheckService = new QuizCheckService();
        _quizService = new QuizService(_mockLogger.Object, _mockRepository.Object,_mockSolutionRepository.Object);
    }

    [Test]
    public void CheckQuestion()
    {
        bool isEqual = _quizCheckService.CheckQuestion(_data.GetQuestionDto1(), _data.GetQuestion1());
        Assert.IsTrue(isEqual);
    }
    
    [Test]
    public void CheckSolvedQuiz()
    {
        var shuffleQuiz = _quizService.Shuffle(_data.GetQuiz1());
        var score = _quizCheckService.CheckSolvedQuiz(_data.GetQuizDto1(), shuffleQuiz);
        Assert.AreEqual(3,score);
    }
    
    [Test]
    public void AddItem()
    {
        var result = _quizService.AddItemAsync(_data.GetQuizDto1(),new CancellationToken()).Result;
    }
}