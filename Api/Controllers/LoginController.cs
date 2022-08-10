using System.Net;
using Core.Interfaces;
using Domain.Dto;
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
    
    [HttpPost]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> Post(LoginDto user,CancellationToken cancellationToken)
    {
        return Ok(await service.LoginAsync(user,cancellationToken));
    }
}