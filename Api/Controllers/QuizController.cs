using System.Net;
using Core.Interfaces;
using Domain.Common;
using Domain.Dto;
using Domain.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Api.Controllers;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _service;
    
    public QuizController(IQuizService service)
    {
        _service = service;
    }
    
    /// <summary>w3w
    /// Create
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = Roles.AutorizedUsers)]
    [HttpPost]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> Post(QuizDto item,CancellationToken cancellationToken)
    {
        var result = _service.AddItem(item, cancellationToken);
        return Ok(result);
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