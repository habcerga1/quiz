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
    
    /// <summary>
    /// Add new Quiz
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Link to the quiz</returns>
    [Authorize(Roles = Roles.AutorizedPostNewQuizzes)]
    [HttpPost]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> Post(QuizDto item,CancellationToken cancellationToken)
    {
        return Ok(await _service.AddItemAsync(item, cancellationToken));
    }
    
    /// <summary>
    /// Post quiz solution
    /// </summary>
    /// <param name="item">User quiz solution from Front-end</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Solution Link</returns>
    [Authorize(Roles = Roles.AutorizedPostNewQuizzes)]
    [HttpPost("PostSolution")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> PostSolution(QuizDto item,CancellationToken cancellationToken)
    {
        return Ok(await _service.AddSolutionAsync(User,item, cancellationToken));
    }
    
    /// <summary>
    /// Get quiz by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetItemById")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> GetItemById(string id,CancellationToken cancellationToken)
    {
        return Ok(await _service.GetItemAsync(id,cancellationToken));
    }
    
    /// <summary>
    /// Get item by category
    /// </summary>
    /// <param name="theme"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetItemsByCategory")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> GetItemsByCategory(string theme,CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [HttpGet]
    [Route("GetItemsByEmail")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> GetItemsByEmail(string email,CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [HttpGet]
    [Route("GetItemsByUser")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> GetItemsByUser(CancellationToken cancellationToken)
    {
        return Ok();
    }
}