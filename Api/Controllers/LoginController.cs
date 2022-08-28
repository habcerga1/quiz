using System.Net;
using Core.Interfaces;
using Domain.Dto;
using Domain.Token;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

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
        var response = await service.LoginAsync(user, cancellationToken);
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