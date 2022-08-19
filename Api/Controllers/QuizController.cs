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
public class QuizController : ControllerBase
{
    public QuizController()
    {
    }
    
    /// <summary>w3w
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
        return Ok();
    }
    
    [HttpPost]
    [Route("refresh")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> Refresh(Token token,CancellationToken cancellationToken)
    {
        return Ok();
    }
}