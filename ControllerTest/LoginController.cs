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
    private ServiceResult<Token> _token;
    
    public LoginControllerTest()
    {
        _application = new ApiServer();
        _client = _application.CreateClient();
        _loginDto = new LoginDto()
        {
            Email = "administrator@mail.com",
            Password = "7am8a5up3R!"
        };
    }
    
    /// <summary>
    /// Testing login controller 
    /// </summary>
    /// <returns>ServiceResult<Token> Token and Refresh Token</returns>
    [Fact]
    public async Task<ServiceResult<Token>> Login()
    {
        var response = await _client.PostAsync("/api/v1.0/Login",ContentService.CreateStringContent(_loginDto));
        _token = await response.Content.ReadAsAsync<ServiceResult<Token>>();
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        return  await response.Content.ReadAsAsync<ServiceResult<Token>>();
    }
    
    /// <summary>
    /// Test refresh token
    /// </summary>
    /// <returns>ServiceResult<Token> Token and Refresh Token</returns>
    [Fact]
    public async Task<ServiceResult<Token>> Refresh()
    {
        ServiceResult<Token> result = await this.Login();
        var response = await _client.PostAsync("/api/v1.0/Login/refresh",ContentService.CreateStringContent(result.Data));
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        return  await response.Content.ReadAsAsync<ServiceResult<Token>>();
    }

    public void Dispose()
    {
        _application.Dispose();
        _client.Dispose();
    }
}