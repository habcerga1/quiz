using System.Net;
using System.Security.Claims;
using Core.Services;
using Domain.Common;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Sentry;
using User = Domain.Models.Base.User;

namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class ServerController : ControllerBase
{
    private readonly IUserRepository _userDb;

    public ServerController(BaseMsSqlContext context,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
    {
        _userDb = new UserRepository(context, userManager,roleManager);
    }


    /// <summary>
    /// Check server status
    /// </summary>
    /// <remarks>
    /// Simple request: GET http://localhost:5038/api/v1/server
    /// </remarks>
    /// <returns>Return date time</returns>
    
    [HttpGet()]
    [SwaggerResponse(HttpStatusCode.OK, typeof(DateTime), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad request Found")]
    public async Task<IActionResult> Get()
    {
        return await Task.Run(()=> Ok(DateTime.Now));
    }
    
    /// <summary>
    /// Check server status
    /// </summary>
    /// <remarks>
    /// Simple request: GET http://localhost:5038/api/v1/server
    /// </remarks>
    /// <returns>Return date time</returns>
    
    [Authorize(Roles = Roles.AutorizedUsers)]
    [HttpGet()]
    [Route("CheckAutorizedUsers")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(DateTime), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad request Found")]
    public async Task<IActionResult> CheckAutorizedUsers()
    {
        Console.WriteLine(User.FindFirstValue(ClaimTypes.Email));
        return await Task.Run(()=> Ok($"{User.Identity.AuthenticationType} CheckAutorizedUsers"));
    }
    
    /// <summary>
    /// Check server status
    /// </summary>
    /// <remarks>
    /// Simple request: GET http://localhost:5038/api/v1/server
    /// </remarks>
    /// <returns>Return date time</returns>
    
    [Authorize(Roles = Roles.AutorizedPostNewQuizzes)]
    [HttpGet()]
    [Route("CheckAutorizedPostNewQuizzes")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(DateTime), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad request Found")]
    public async Task<IActionResult> CheckAutorizedPostNewQuizzes()
    {
        return await Task.Run(()=> Ok($"{User.Identity.AuthenticationType} CheckAutorizedPostNewQuizzes"));
    }
}