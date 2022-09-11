using Core.Interfaces;
using Core.Services;
using Domain.Dto;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTests;

public class UserServiceTest
{
    private Mock<ILogger<UserService>> _mockLogger = new Mock<ILogger<UserService>>();
    private Mock<ISolutionResultRepository> _mockSolutionRepository = new Mock<ISolutionResultRepository>();
    private Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
    private Mock<ITokenRepository> _tokenRepositoryMock = new Mock<ITokenRepository>();
    private Mock<ITokenService> _tokenServiceMock = new Mock<ITokenService>();
    private IUserService _userService;
    private LoginDto _loginDto;
    
    [SetUp]
    public void Setup()
    {
        _loginDto = new LoginDto() { Email = "some@mail.com", Password = "adaadasdasd#434!!"};
        _userService = new UserService(_userRepositoryMock.Object, _mockLogger.Object, _tokenServiceMock.Object, _tokenRepositoryMock.Object);
    }

    [Fact]
    public async Task LoginAsyncExceptionTest()
    {
        var result = await _userService.LoginAsync(_loginDto,new CancellationToken());
        
    }
    
    
}