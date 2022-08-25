using System.Text;
using ControllerTest.Host;
using ControllerTest.Services;
using Domain.Common;
using Domain.Dto;
using Domain.Token;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace ControllerTest;

public class LoginControllerTest : IDisposable
{
    private ApiServer _application;
    private HttpClient _client;

    private LoginDto _loginDto;
    
    public LoginControllerTest()
    {
        _application = new ApiServer();
        _client = _application.CreateClient();
        _loginDto = new LoginDto()
        {
            Email = "admin@admin.com",
            Password = "7am8a5up3R!"
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns>ServiceResult<Token> Token and Refresh Token</returns>
    [Fact]
    public async Task<ServiceResult<Token>> Post()
    {
        var response = await _client.PostAsync("/api/v1.0/Login",ContentService.CreateStringContent(_loginDto));
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        return  await response.Content.ReadAsAsync<ServiceResult<Token>>();
    }

    public void Dispose()
    {
        _application.Dispose();
        _client.Dispose();
    }
}