using System.Net;
using Core.Interfaces;
using Domain.Dto;
using Domain.Token;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Sentry;

namespace Api.Controllers;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class LoginController : ControllerBase
{
    private readonly IUserService service;
    public LoginController(IUserService _service)
    {
        service = _service;
    }
    
    /// <summary>
    /// Create
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> Post(LoginDto user,CancellationToken cancellationToken)
    {
        var transaction = SentrySdk.StartTransaction("user-login-transaction", "controller-login-post");
        var response = await service.LoginAsync(user, cancellationToken);
        var span = transaction.StartChild("test-child-operation");
        span.Finish();
        transaction.Finish();
        return Ok(response);
    }
    
    [HttpPost]
    [Route("refresh")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> Refresh(Token token,CancellationToken cancellationToken)
    {
        return Ok(await service.RefreshTokenAsync(token, cancellationToken));
    }
}