using System.Text;
using ControllerTest.Host;
using ControllerTest.Services;
using Domain.Common;
using Domain.Dto;
using Domain.Token;
using MongoDB.Bson.IO;
using TestData;


namespace ControllerTest;

public class QuizController : IDisposable
{
    private ApiServer _application;
    private HttpClient _client;
    private LoginControllerTest _loginController;

    public QuizController()
    {
        _application = new ApiServer();
        _client = _application.CreateClient();
        _loginController = new LoginControllerTest();
    }
    
    /// <summary>
    /// Testing when user authorization and post new quiz.
    /// </summary>
    /// <returns>ServiceResult<Token></returns>
    [Fact]
    public async Task AddNewQuiz()
    {
        var token = await _loginController.Login();
        
        _client.DefaultRequestHeaders.Add("Accept", "application/json");
        _client.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Data.Access_Token);
        
        var response = await _client.PostAsync("/api/v1.0/Quiz",ContentService.CreateStringContent(new TestQuiz().GetQuizDto1())); 
        Assert.NotNull(response);
    }
    
    /// <summary>
    /// Testing when user get quiz by id and then send solution.
    /// </summary>
    /// <returns>ServiceResult<Token></returns>
    [Fact]
    // TODO: Нужно протестировать
    public async Task PostSolution()
    {
        var token = await _loginController.Login();
        
        _client.DefaultRequestHeaders.Add("Accept", "application/json");
        _client.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Data.Access_Token);

        var item = await _client.GetAsync("api/v1.0/Quiz/GetItemById?Id=62e2deedf131b457549f847e");
        var response = await _client.PostAsync("/api/v1.0/Quiz/PostSolution",ContentService.CreateStringContent(new TestQuiz().GetQuizDto1())); 
        Assert.NotNull(response);
    }

    public void Dispose()
    {
        _application.Dispose();
        _client.Dispose();
        _loginController.Dispose();
    }
}