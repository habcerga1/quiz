using ControllerTest.Host;
using ControllerTest.Services;
using Domain.Dto;

namespace ControllerTest;

public class RegistrationController : IDisposable
{
    private ApiServer _application;
    private HttpClient _client;

    private RegistrationDto _itemDto;
    
    public RegistrationController()
    {
        _application = new ApiServer();
        _client = _application.CreateClient();
        _itemDto = new RegistrationDto()
        {
            Email = "user1@user.com",
            Password = "7am8a5up3R!",
            FirstName = "Ivan",
            LastName = "Ivanov"
        };
    }

    [Fact]
    public async Task Post()
    {
        var response = await _client.PostAsync("/api/v1.0/Registration",ContentService.CreateStringContent(_itemDto));
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    public void Dispose()
    {
        _application.Dispose();
        _client.Dispose();
    }
}